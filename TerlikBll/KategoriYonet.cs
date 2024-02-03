using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerlikEntities;
using TerlikDAL;

namespace TerlikBll
{
    public class KategoriYonet
    {
        Repository<Category> rep_kat = new Repository<Category>();
        
        public List<Category> Listele()
        {
            return rep_kat.Liste();
        }

        public Category Kategoribul(int id)
        {
            return rep_kat.Find(x => x.CategoryId == id);// kategorinin tüm kaydını buluyor burada
        }
    }
}
