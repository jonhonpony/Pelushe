using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using TerlikEntities;
using TerlikBll;

namespace Terlik_yeni.Models
{
    public class CacheHelper
    {
        // cache helper yazmamız lazım çünkü her seferinde veritabanına gidip veri çekmek yerine cache den çekmek daha mantıklı bunun kodu ise şu şekildedir 
        public static List<Category> KategoriCache()
        {
            var kategoriler = WebCache.Get("kat-cache"); // cache de varsa getir yoksa null döndürür yok ise aşağıdaki kodu çalıştırır ve cache e ekler 
            if (kategoriler == null)
            {
                KategoriYonet ky = new KategoriYonet();
                kategoriler = ky.Listele();
                WebCache.Set("kat-cache", new KategoriYonet().Listele(), 20, true); // 20 dakika sonra cache silinir 
            }

            return kategoriler;
        }
        public static void CacheTemizle()
        {
            WebCache.Remove("kat-cache");

        }

    }
}