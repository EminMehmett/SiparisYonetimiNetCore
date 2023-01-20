using SiparisYonetimiNetCore.Data;
using SiparisYonetimiNetCore.Data.Concrete;
using SiparisYonetimiNetCore.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimiNetCore.Service.Concrete
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(DatabaseContext context) : base(context)
        {
        }
    }
}
