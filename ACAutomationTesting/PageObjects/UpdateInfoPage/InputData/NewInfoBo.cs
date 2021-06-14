using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Author:Dima Raul Andrei
/// </summary>
namespace ACAutomationTesting.PageObjects.UpdateInfoPage.InputData
{
    public class NewInfoBo
    {
        public string Nume { get; set; } = "Dima Raul Andrei";
        public string Email { get; set; } = "gandrei5@yahoo.com";
        public string Telefon { get; set; } = "0753080524";
        public string OldPass { get; set; } = "12345678";
        public string NewPass { get; set; } = "abcdefgh";
        public string ConfirmPass { get; set; } = "abcdefgh";
    }
}
