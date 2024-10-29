namespace Utils
{
    public static class Constants
    {
        #region Units

        public const string I = "I"; //1
        public const string IV = "IV"; //4
        public const string V = "V"; //5
        public const string IX = "IX"; //9

        public const string I_BecomesIV = "IIII"; //4
        public const string I_BecomesV = "IIIII"; //5
        public const string VI_BecomesIX = "VIIII"; //9

        #endregion

        #region Tens

        public const string X = "X"; //10
        public const string XL = "XL"; //40
        public const string L = "L"; //50
        public const string XC = "XC"; //90

        public const string V_BecomesX = "VV"; //10
        public const string X_BecomesXL = "XXXX"; // 40
        public const string X_BecomesL = "XXXXX"; //50
        public const string LX_BecomesXC = "LXXXX"; //90

        #endregion

        #region Hundreds

        public const string C = "C"; //100
        public const string CD = "CD"; //400
        public const string D = "D"; //500
        public const string CM = "CM"; //900
        public const string L_BecomesC = "LL"; //100
        public const string C_BecomesCD = "CCCC"; //400
        public const string C_BecomesD = "CCCCC"; //500
        public const string DC_BecomesCM = "DCCCC"; //900

        #endregion

        public const string M = "M";
        public const string D_BecomesM = "DD"; //1000


        public const string Yes = "Y";
        public const string No = "N";
        public const char ZeroChar = '0';
    }
}