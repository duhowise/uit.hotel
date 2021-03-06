using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PositionBusiness
    {
        public static Task<Position> Add(Position position)
        {
            CheckUniqueName(position);
            return PositionDataAccess.Add(position);
        }

        public static Task<Position> Update(Position position)
        {
            var positionInDatabase = GetAndCheckValid(position.Id);
            CheckUniqueName(position, true);

            return PositionDataAccess.Update(positionInDatabase, position);
        }

        public static void Delete(int positionId)
        {
            var positionInDatabase = GetAndCheckValid(positionId);
            PositionDataAccess.Delete(positionInDatabase);
        }

        public static void SetIsActive(int positionId, bool isActive)
        {
            var positionInDatabase = Get(positionId);
            if (positionInDatabase == null)
                throw new Exception("Chức vụ có ID: " + positionId + " không tồn tại");

            if (!isActive && positionInDatabase.Employees.Where(e => e.IsActive).Count() > 0)
                throw new Exception("Chức vụ này còn nhân viên đang hoạt động sử dụng");

            PositionDataAccess.SetIsActive(positionInDatabase, isActive);
        }

        private static void CheckUniqueName(Position position, bool isUpdate = false)
        {
            var positions = Get().Where(p => p.Name == position.Name && (isUpdate ? p.Id != position.GetManaged().Id : true));
            if (positions.Count() == 1 && positions.First().Id != position.Id)
                throw new Exception("Chức vụ " + position.Name + " đã được tạo.");
            else if (positions.Count() > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
        }

        public static void SetIsActiveAndMoveEmployee(int id, int newId, bool isActive)
        {
            var positionInDatabase = Get(id);
            if (positionInDatabase == null)
                throw new Exception("Chức vụ có ID: " + id + " không tồn tại");

            var positionNew = Get(newId);
            if (positionNew == null)
                throw new Exception("Chức vụ có ID: " + newId + " không tồn tại");
            if (!positionNew.IsActive)
                throw new Exception("Chức vụ có ID: " + newId + " đã bị vô hiệu hóa");

            if (id == newId)
                throw new Exception("Chức vụ trùng nhau. Không thể chuyển");

            if (isActive) throw new Exception("Chức năng này chỉ được dùng để vô hiệu hóa chức vụ");

            PositionDataAccess.SetIsActiveAndMoveEmployee(positionInDatabase, positionNew);
        }

        private static Position GetAndCheckValid(int positionId)
        {
            var positionInDatabase = Get(positionId);
            if (positionInDatabase == null)
                throw new Exception("Chức vụ có ID: " + positionId + " không tồn tại");

            if (positionInDatabase.Employees.Count() > 0)
                throw new Exception("Không thể cập nhật/xóa. Chức vụ đang có nhân viên sử dụng");

            return positionInDatabase;
        }

        public static void UpdateForHelper(Action<Position> setPermission, Position position)
            => PositionDataAccess.UpdateForHelper(setPermission, position);

        public static Position Get(int positionId) => PositionDataAccess.Get(positionId);

        public static IEnumerable<Position> Get() => PositionDataAccess.Get();
    }
}
