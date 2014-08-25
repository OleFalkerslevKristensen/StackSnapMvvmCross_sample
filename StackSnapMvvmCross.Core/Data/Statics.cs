using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StackSnapMvvmCross.Core.Data
{
    public static class Statics
    {
        // Public constants

        public static string APP_PATH_SD_CARD = "/sScale/";
        public static string APP_THUMBNAIL_PATH_SD_CARD = "scaledImages/";
           
        public static double SCREENINCHES = 0;
        public const int SCREENLIMIT = 6;    // In inches   
        public static int GPSACCURACY = 50;

        public const int DIALOG_YES_NO_MESSAGE_GPS = 1;
        public const int DIALOG_YES_NO_DELETE = 2;
        public const int DIALOG_CONTINUE_WORK = 3;
        public const int DIALOG_SEND_CONFIRM = 4;
        public const int DIALOG_DELETE_ALL = 5;
        public const int DIALOG_LOGOUT = 6;

        public const int MAX_IMAGE_SIZE = 2000000; //2 MB

        public static int GPSAccuracy = 50;

        public static List<string> species = new List<string>();
        public static List<string> kind = new List<string>();
        public static List<string> source = new List<string>();
        public static List<string> destination = new List<string>();

 //       public static GeoHelper Geo;
 

        
    }
}