﻿namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class LoginResponseDto
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public int? UserId { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
    }
}
