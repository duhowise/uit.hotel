﻿using System;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public class Position : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool PermissionCleaning { get; set; }
        public bool PermissionGetAccountingVoucher { get; set; }
        public bool PermissionGetMap { get; set; }
        public bool PermissionGetPatron { get; set; }
        public bool PermissionGetPrice { get; set; }
        public bool PermissionGetService { get; set; }
        public bool PermissionManageEmployee { get; set; }
        public bool PermissionManageMap { get; set; }
        public bool PermissionManagePatron { get; set; }
        public bool PermissionManagePatronKind { get; set; }
        public bool PermissionManagePosition { get; set; }
        public bool PermissionManagePrice { get; set; }
        public bool PermissionManageRentingRoom { get; set; }
        public bool PermissionManageService { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(Employee.Position))]
        public IQueryable<Employee> Employees { get; }

        public Position GetManaged()
        {
            var position = PositionBusiness.Get(Id);
            if (position == null)
                throw new Exception("Mã chức vụ không tồn tại");
            return position;
        }
    }
}
