using MauiFirebase.mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebase.FirebaseMaui
{
    public interface IFirestore
    {
        bool notekle(NotOzellikleri notOzellikleri);
        bool notguncelle(NotOzellikleri notOzellikleri);
        bool notusil(NotOzellikleri notOzellikleri);
       // Task<IList<NotOzellikleri>> ReadNotList();
    }
    internal class FirebaseFirestore
    {
        static IFirestore firestore = new MauiFirebase.Platforms.FirebaseFirestoreSah();
        public static bool notekle(NotOzellikleri notOzellikleri)
        {
            return firestore.notekle(notOzellikleri);
        }
        public static bool notguncelle(NotOzellikleri notOzellikleri)
        {
            return firestore.notguncelle(notOzellikleri);
        }
        public static bool notusil(NotOzellikleri notOzellikleri)
        {
            return firestore.notusil(notOzellikleri);
        }
        //public static Task<IList<NotOzellikleri>> ReadNotList()
        //{
        //    return firestore.ReadNotList();
        //}
    }
}
