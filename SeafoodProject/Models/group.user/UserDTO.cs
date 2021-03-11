using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafoodProject.Models.group.user
{
    public class UserDTO
    {
        private int userId;
        private string userName;
        private string password;
        private int role;
        private string fullName;
        private string phoneNumber;
        private string address;
        private int status;

        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public int Status { get => status; set => status = value; }

        public UserDTO()
        {
        }

        public UserDTO(int userId, string userName, string password, int role, string fullName, string phoneNumber, string address, int status)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.role = role;
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is UserDTO dTO &&
                   userId == dTO.userId &&
                   userName == dTO.userName &&
                   password == dTO.password &&
                   role == dTO.role &&
                   fullName == dTO.fullName &&
                   phoneNumber == dTO.phoneNumber &&
                   address == dTO.address &&
                   status == dTO.status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(userId, userName, password, role, fullName, phoneNumber, address, status);
        }
    }
}
