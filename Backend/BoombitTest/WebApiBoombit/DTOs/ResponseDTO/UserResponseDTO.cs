using System;
namespace WebApiBoombit.DTOs.ResponseDTO
{
    public class UserResponseDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Country { set; get; }
        public Int64? PhoneNumber { set; get; }
        public bool NeedInformation { set; get; }
    }
}

