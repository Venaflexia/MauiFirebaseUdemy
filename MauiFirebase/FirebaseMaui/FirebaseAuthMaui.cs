using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiFirebase.FirebaseMaui
{
    public interface IAuth
    {
        Task<bool> GirisYap(string email, string sifre);
        Task<bool> KayitOl(string username, string email, string sifre);
        bool GirisYapildimi();
    }
    internal class FirebaseAuthMaui
    {
        static IAuth auth = new MauiFirebase.Platforms.FirebaseAuthSah();
        public static async Task<bool> GirisYap(string email, string sifre)
        {
            return await auth.GirisYap(email, sifre);
        }

        public static bool GirisYapildimi()
        {
            return auth.GirisYapildimi();
        }

        public static async Task<bool> KayitOl(string username, string email, string sifre)
        {
            return await auth.KayitOl(username, email, sifre);
        }
    }
}
