using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO.IsolatedStorage;
using System.IO;
using System.Text.RegularExpressions;
using Android.Graphics;
using System.Reflection;
using Android.Content;
//using sScale.ViewModels;
using Java.IO;
//using sScale.Activities;
using Android.Widget;
using StackSnapMvvmCross.Core.Data;
using StackSnapMvvmCross.Droid.Views;

namespace StackSnapMvvmCross.Droid.Storage
{
    class StorageHandler
    {

        public List<UserData> GetUserList()
        {
            List<UserData> userList = null;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Userlist.xml", FileMode.Open))
                    {
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<UserData>));

                            userList = new List<UserData>();
                            userList = (List<UserData>)serializer.Deserialize(stream);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return userList;
        }


        public void StoreUserList(List<UserData> userList)
        {
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Userlist.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<UserData>));

                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, userList);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }


        public bool DeleteUserList()
        {
            bool rc = false;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    myIsolatedStorage.DeleteFile("Userlist.xml");
                    rc = true;
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return rc;
        }


        public UserData GetUser()
        {
            UserData userData = null;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("User.xml", FileMode.Open))
                    {
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
                    
                            userData = (UserData)serializer.Deserialize(stream);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return userData;
        }


        public void StoreUser(UserData user)
        {
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    // Name of file should be Aalto ID
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("User.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(UserData));

                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, user);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }


        public bool DeleteUser()
        {
            bool rc = false;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    myIsolatedStorage.DeleteFile("User.xml");
                    rc = true;
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return rc;
        }

        public void updateUserList(UserData user)
        {
            
            List<UserData> userList;

            DeleteUser();
            StoreUser(user);

            if (GetUserList() == null)
            {
                userList = new List<UserData>();
            }
            else
            {

                userList = GetUserList();

                // Check if credential already exists

                try
                {

                    if (userList.Any(item => item.UserName == user.UserName))
                    {
                        UserData userToDelete = userList.Find(item => item.UserName == user.UserName);

                        userList.Remove(userToDelete);
                    }
                }
                catch { }

            }

            userList.Insert(0, user);

            StoreUserList(userList);
        }



        public List<StackData> GetStackList()
        {
            List<StackData> stackList = null;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Stacklist.xml", FileMode.Open))
                    {
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<StackData>));

                            stackList = new List<StackData>();
                            stackList = (List<StackData>)serializer.Deserialize(stream);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return stackList;
        }



        public void StoreStackList(List<StackData> stackList)
        {
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                   
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Stacklist.xml", FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<StackData>));

                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, stackList);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }


        public bool DeleteStackList()
        {
            bool rc = false;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    myIsolatedStorage.DeleteFile("Stacklist.xml");
                    rc = true;
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return rc;
        }



        public List<string> GetStringList(string path)
        {
            List<string> stringList = null;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(path, FileMode.Open))
                    {
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                            stringList = new List<string>();
                            stringList = (List<string>)serializer.Deserialize(stream);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return stringList;
        }


        public void StoreStringList(List<string> stringList, string path)
        {
            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {

                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(path, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

                        using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                        {
                            serializer.Serialize(xmlWriter, stringList);
                        }
                        stream.Close();
                    }
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
        }

        public bool DeleteStringList(string path)
        {
            bool rc = false;
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    myIsolatedStorage.DeleteFile(path);
                    rc = true;
                    myIsolatedStorage.Dispose();
                }
            }
            catch (Exception e)
            {

            }
            return rc;
        }


        public bool StoreContent(Bitmap content, string name, NewStackView context)
        {
            Regex rgx = new Regex("[^0-9]");
            name = rgx.Replace(name, "");
            name = name + "_content.jpg";


            string dir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + Statics.APP_PATH_SD_CARD + Statics.APP_THUMBNAIL_PATH_SD_CARD;

            if (Android.OS.Environment.MediaMounted == Android.OS.Environment.ExternalStorageState)
            {
                try
                {
       
                    if (!System.IO.Directory.Exists(dir))
                         System.IO.Directory.CreateDirectory(dir);
             

                    System.IO.Stream fos = new System.IO.FileStream(dir + name, System.IO.FileMode.Create);
                    content.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, fos);
                    fos.Flush();
                    fos.Close();
                    content.Dispose();
                  

                }
                catch (Exception exc)
                {
                    return false;
                }

                return true;
            }
            else return false;

        }

      
        public void deleteContent(string file)
        {

            try
            {
                System.IO.File.Delete(file);
            }
            catch (Exception e)
            {
                
            }
        }


        public void deleteAllContents()
        {
            string dir = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + Statics.APP_PATH_SD_CARD + Statics.APP_THUMBNAIL_PATH_SD_CARD;
         
            try
            {
                if (System.IO.Directory.Exists(dir))
                {
                    string[] Files = Directory.GetFiles(dir);
                    
                    foreach (string file in Files)
                    {
                         System.IO.File.Delete(file);
                    }

                    System.IO.Directory.Delete(dir);

                }
                  
            }
            catch (Exception e)
            {

            }


        }

        public string GetFilePath(string name)
        {
            Regex rgx = new Regex("[^0-9]");
            name = rgx.Replace(name, "");

            name = name + "_content.jpg";

            string fullPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + Statics.APP_PATH_SD_CARD + Statics.APP_THUMBNAIL_PATH_SD_CARD;

            return fullPath + name;
        }

    }
}
