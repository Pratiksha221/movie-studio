using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PratikshaStudio.BusinessEntities;
using PratikshaStudio.DataAccess;

namespace PratikshaStudio.BusinessAccess
{
    public class CommonBusinessAccess
    {
        private CommonDataAccess _commonDA;

        public CommonBusinessAccess()
        {
            _commonDA = new CommonDataAccess();
        }
        public List<CommonBE> GetAllGenreId()
        {
            try
            {
                return _commonDA.GetAllGenreId();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<CommonBE> GetAllRatingId()
        {
            try
            {
                return _commonDA.GetAllRatingId();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommonBE> GetAllActorId()
        {
            try
            {
                return _commonDA.GetAllActorId();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
