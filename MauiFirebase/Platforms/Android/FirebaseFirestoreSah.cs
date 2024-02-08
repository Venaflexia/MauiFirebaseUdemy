using Android.Gms.Tasks;
using Android.Runtime;
using Firebase;
using Firebase.Firestore;
using Java.Util;
using MauiFirebase.FirebaseMaui;
using MauiFirebase.mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebase.Platforms
{
    internal class FirebaseFirestoreSah : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<NotOzellikleri> NotList;
        bool hasReadNotList = false;
        public FirebaseFirestoreSah()
        {
            NotList = new List<NotOzellikleri>();
        }
        public bool notekle(NotOzellikleri notOzellikleri)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("NotBilgisi");
                var document = new JavaDictionary<string, Java.Lang.Object>
            {
                {"author",Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid},
                {"notİçeriği",notOzellikleri.Icerik },
                {"paylaşılmaTarihi",DateTimeToNativeDate(notOzellikleri.OlusturulmaTarihi) },
                {"paylaşanKişi",notOzellikleri.PaylasanKisi }
            };
                collection.Add(document);
                //collection.Document("Babürşah").Set(document);
                return true;
            }

            catch (Exception)
            {

                return false;
            }

        }
        private static Date DateTimeToNativeDate(DateTime date)
        {
            //long dateTimeUtcAsMillisecond = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            //    ).TotalMicroseconds;
            long unixTime = ((DateTimeOffset)date.ToUniversalTime()).ToUnixTimeMilliseconds();

            return new Date(unixTime);
        }

        public bool notguncelle(NotOzellikleri notOzellikleri)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("NotBilgisi");
                collection.Document(notOzellikleri.Id).Update("paylaşanKisi", notOzellikleri.PaylasanKisi, "notİçeriği", notOzellikleri.Icerik);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool notusil(NotOzellikleri notOzellikleri)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("NotBilgisi");
                collection.Document(notOzellikleri.Id).Delete();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<IList<NotOzellikleri>> ReadNotList()
        {
            hasReadNotList = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("NotBilgisi");
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            query.Get().AddOnCompleteListener(this);

            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadNotList)
                {
                    break;
                }
            }
            return NotList;
        }
        private static DateTime NativeDateToDateTime(Timestamp stamp)
        {

            DateTime reference = new DateTime(1970, 1, 1, 1, 0, 0).ToLocalTime();

            DateTime converted = reference.AddSeconds(stamp.Seconds);

            return converted;

        }
        public void OnComplete(global::Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var document = (QuerySnapshot)task.Result;

                NotList.Clear();
                foreach (var doc in document.Documents)
                {
                    NotOzellikleri not = new NotOzellikleri
                    {

                        Icerik = doc.Get("notİçeriği").ToString(),
                        UserId = doc.Get("author").ToString(),
                        PaylasanKisi = doc.Get("paylaşanKişi").ToString(),
                        OlusturulmaTarihi = NativeDateToDateTime(doc.Get("paylaşılmaTarihi") as Timestamp),
                        Id = doc.Id

                    };
                    NotList.Add(not);
                }
            }
            else
            {
                NotList.Clear();
            }
            hasReadNotList = true;
        }
    }
}
