using System;
using System.ComponentModel;

namespace StackSnapMvvmCross.Core.Data
{
    public class StackData 
    {
        public enum eStackStatus
        {
            Notsent,
            Sent,
            Draft
        }
        
        
        public string StackId
        {
            get;
            set;
        }

        public string Picture
        {
            get;
            set;
        }


        public double Latitude
        {
            get;
            set;
        }


        public double Longitude
        {
            get;
            set;
        }


        public string Species
        {
            get;
            set;
        }

        public string Kind
        {
            get;
            set;
        }

        public string Volume
        {
            get;
            set;
        }

        public string Depth
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public string Time
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public string Destination
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public string accuracy
        {
            get;
            set;
        }

        public string scaledPath
        {
            get;
            set;
        }
      

    }

}
