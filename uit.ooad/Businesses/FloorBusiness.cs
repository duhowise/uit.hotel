﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class FloorBusiness
    {
        public static Task<Floor> Add(Floor floor) => FloorDataAccess.Add(floor);
        public static Task<Floor> Update(Floor floor)
        {
            var floorInDatabase = FloorDataAccess.Get(floor.Id);
            if (floorInDatabase != null && floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể cập nhật!");
            return FloorDataAccess.Update(floor);
        }
        public static void Delete(int floorId)
        {
            var floorInDatabase = Get(floorId);
            if (floorInDatabase == null)
                throw new Exception("Tầng có Id=" + floorId + " không hợp lệ!");
            if (floorInDatabase.Rooms.Count() > 0)
                throw new Exception("Tầng đã có phòng. Không thể xóa!");
            FloorDataAccess.Delete(floorInDatabase);
        }
        public static void SetIsActive(int floorId, bool isActive)
        {
            var floorInDatabase = FloorDataAccess.Get(floorId);
            if (floorInDatabase == null)
                throw new Exception("Tầng có Id=" + floorId + " không hợp lệ!");
            FloorDataAccess.SetIsActive(floorId, isActive);
        }
        public static Floor Get(int floorId) => FloorDataAccess.Get(floorId);
        public static IEnumerable<Floor> Get() => FloorDataAccess.Get();
    }
}
