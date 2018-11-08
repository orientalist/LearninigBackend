using System.ComponentModel.DataAnnotations;

namespace CoreMVCBackend.Models{
    public class LogInModel{
        
        [Required]
        public string Account_Account{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Account_Password{get;set;}
    }
}