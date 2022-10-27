namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class ForgetPasswordResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
      
        public string Errors { get; set; }
        public dynamic Data { get; set; }
       
    }
}
