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
        public string Nume { get; set; } = "test";
        public string Email { get; set; } = "test@yahoo.com";
        public string Telefon { get; set; } = "0752974576";
        public string OldPass { get; set; } = "test1234";
        public string NewPass { get; set; } = "test1234";
        public string ConfirmPass { get; set; } = "test1234";

        //Melinte Alexandru-Gicu
        public string DataNasterii { get; set; } = "1998-10-21";
    }
}
