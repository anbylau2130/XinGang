using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.XinGang.Model.Model;
using Repository.Domain;
using Repository.Domain.Infrastructure;

namespace Repository.DAL.Repository
{
    public class ContentTypeRepository : Repository<ContentType>
    {
        public ContentTypeRepository(XinGangDbContext dbContext) : base(dbContext)
        {

        }
    }
}
