using Android.Runtime;
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
    internal class FirebaseFirestoreSah:IFirestore
    {
        public FirebaseFirestoreSah()
        {
         
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
    }
}
