using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
	public class StaffManager : IStaffService
	{
		private readonly IStaffDal _staffDal;

		public StaffManager(IStaffDal staffDal)
		{
			_staffDal = staffDal;
		}

		public void TDelete(Staff t)
		{
			_staffDal.Delete(t);
		}

		public Staff TGetById(int id)
		{
			return _staffDal.GetById(id);
		}

		public List<Staff> TGetList()
		{
			return _staffDal.GetList();
		}

		public void TInsert(Staff t)
		{
			_staffDal.Insert(t);
		}

		public void TUpdate(Staff t)
		{
			_staffDal.Update(t);
		}
	}
}
