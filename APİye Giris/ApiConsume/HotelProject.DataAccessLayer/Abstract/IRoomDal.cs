using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IRoomDal:IGenaricDal<Room> //IGenaricDal'dan miras alıcak ama Room sınıfı için çalışacak
    {
        int RoomCount();
    }
}
