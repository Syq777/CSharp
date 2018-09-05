using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace OS
{
    public class FCB
    {
        byte[] _name = new byte[3];//文件名
        byte[] _type = new byte[2];//文件后缀     
        byte _attribute;//文件属性
        byte _address;//文件起始地址
        byte _length;//文件长度
        public FCB()
        {

        }
        public FCB(int i)
        {
            if(i==0)
            {
                SetType("  ");
                SetAttribute(8);
                SetLength(0);
            }
        }
        public FCB(byte[] sname, byte[] stype, byte sattribute, byte saddress, byte slength)
        {
            for (int i = 0; i < 3; i++)
                _name[i] = sname[i];
            for (int i = 0; i < 2; i++)
                _type[i] = _type[i];
            _attribute = sattribute;
            _address = saddress;
            _length = slength;
        }
        public void SetName(string sname)
        {
            _name = Encoding.Default.GetBytes(sname);
        }
        public void SetName(byte[] sname)
        {
            _name[0] = sname[0];
            _name[1] = sname[1];
            _name[2] = sname[2];
        }
        public string GetName()
        {
            return Encoding.Default.GetString(_name);
        }
        public void SetType(string stype)
        {
            _type = Encoding.Default.GetBytes(stype);
        }
        public void SetType(byte[] stype)
        {
            _type[0] = stype[0];
            _type[1] = stype[1];
        }
        public string GetType()
        {
            return Encoding.Default.GetString(_type);
        }
        public void SetAttribute(int sattribute)
        {
            _attribute = (byte)sattribute;
        }
        public int GetAttribute()
        {
            return _attribute;
        }
        public void SetAddress(int saddress)
        {
            _address = (byte)saddress;
        }
        public int GetAddress()
        {
            return _address;
        }
        public void SetLength(int slength)
        {
            _length = (byte)slength;
        }
        public int GetLength()
        {
            return _length;
        }
    }
    class FileFunction
    {
        public void Format(string harddisk)
        {
            FileStream sharddisk = new FileStream(harddisk, FileMode.OpenOrCreate);
            byte[] disk = new byte[8192];
            disk[0] = disk[1] = disk[2] = 255;
            for (int i = 3; i < 8192; i++)
            {
                disk[i] = 0;
            }
            sharddisk.Seek(0, SeekOrigin.Begin);
            sharddisk.Write(disk, 0, 8192);
            sharddisk.Close();
        }
        public int[] SearchAddress(string[] startPath)
        {
            string[] path = new string[3];
            for (int j = 0; j < 3; j++)
                path[j] = startPath[j];
            int[] fileAddress = new int[3];
            fileAddress[0] = 2;
            fileAddress[1] = 64;
            fileAddress[2] = 0;
            int i;                        
            if(path[2] == "")
            {
                fileAddress[0] = 1;
                fileAddress[1] = 0;
                fileAddress[2] = 2;
                return fileAddress;
            }
            FileStream disk = new FileStream(path[0], FileMode.Open);            
            if (path[1].Length != 0)
            {
                string[] spath = path[1].Split(new char[] { '\\' });
                int k = 0;
                while (k < spath.Length)
                {
                    for (i = 0; i < 64; i = i + 8)
                    {
                        disk.Seek(64 * fileAddress[0] + i, SeekOrigin.Begin);
                        byte[] name = new byte[3];
                        disk.Read(name, 0, 3);//读取文件名
                        disk.Seek(64 * fileAddress[0] +i+ 6, SeekOrigin.Begin);
                        int address = disk.ReadByte();
                        if (spath[k] == Encoding.Default.GetString(name))
                        {                         
                            fileAddress[0] = address;
                            break;
                        }
                    }
                    if (i == 64)
                    {                        
                        fileAddress[0] = 0;
                        MessageBox.Show("目录不存在");
                        disk.Close();
                        return fileAddress;
                    }
                    k++;
                }
            }
            
            for (i = 0; i < 64; i = i + 8)
            {
                byte[] name = new byte[3];
                byte[] type = new byte[2];
                disk.Seek(64 * fileAddress[0] + i, SeekOrigin.Begin);                
                disk.Read(name, 0, 3);//读取文件名
                disk.Seek(0, SeekOrigin.Current);
                disk.Read(type, 0, 2);
                string sname = Encoding.Default.GetString(name);
                string stype = Encoding.Default.GetString(type);
                if (Encoding.Default.GetString(type)=="  ")
                {
                    if (path[2] == sname)
                    {
                        fileAddress[1] = i ;
                        disk.Seek(64 * fileAddress[0] + i+6, SeekOrigin.Begin);
                        fileAddress[2] = disk.ReadByte();
                        break;
                    }
                }
                else if(Encoding.Default.GetString(type)!="")
                {
                    if (path[2] == sname + "." + stype)
                    {
                        fileAddress[1] = i;
                        disk.Seek(64 * fileAddress[0] + i+6, SeekOrigin.Begin);
                        fileAddress[2]=disk.ReadByte();
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            disk.Close();
            return fileAddress;
        }
        public int FindItem(int disknum, string harddisk)//寻找空目录项
        {
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            int i;
            for (i = 0; i < 64; i = i + 8)
            {
                disk.Seek(64 * disknum + 4 + i, SeekOrigin.Begin);
                if (disk.ReadByte() == 0)
                {
                    break;
                }
            }
            if (i == 64)
            {
                MessageBox.Show("目录已满");
            }
            disk.Close();
            return i;
        }
        public FCB ReadItem(string harddisk, int disknum, int item)
        {
            FCB fcb = new FCB();
            byte[] name = new byte[3];
            byte[] type = new byte[2];
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(64 * disknum + item, SeekOrigin.Begin);            
            disk.Read(name, 0, 3);
            disk.Seek(0, SeekOrigin.Current);
            disk.Read(type, 0, 2);
            fcb.SetName(name);
            fcb.SetType(type);
            disk.Seek(0, SeekOrigin.Current);
            fcb.SetAttribute(disk.ReadByte());
            disk.Seek(0, SeekOrigin.Current);
            fcb.SetAddress(disk.ReadByte());
            disk.Seek(0, SeekOrigin.Current);
            fcb.SetLength(disk.ReadByte());
            disk.Close();
            return fcb;
        }
        public void WriteItem(string harddisk, int disknum,int item,FCB fcb)
        {
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(64 *disknum + item, SeekOrigin.Begin);
            disk.Write(Encoding.Default.GetBytes(fcb.GetName()), 0, 3);
            disk.Seek(0, SeekOrigin.Current);
            disk.Write(Encoding.Default.GetBytes(fcb.GetType()), 0, 2);
            disk.Seek(0, SeekOrigin.Current);
            disk.WriteByte((byte)fcb.GetAttribute());
            disk.Seek(0, SeekOrigin.Current);
            disk.WriteByte((byte)fcb.GetAddress());
            disk.Seek(0, SeekOrigin.Current);
            disk.WriteByte((byte)fcb.GetLength());
            disk.Close();
        }
        public void DeleteItem(string harddisk, int disknum, int item)
        {
            byte[] zero = new byte[8];
            for(int i=0;i<8;i++)
            {
                zero[i] = 0;
            }
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(64 * disknum + item, SeekOrigin.Begin);
            disk.Write(zero, 0, 8);
            disk.Close();
        }
        public int[] CreatMenu(string[] startPath)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int []disknum = new int[2];            
            disknum[0] = 0;
            FCB fcb=new FCB(0);
            fcb.SetName(path[2]);          
            int[] fileAddress = SearchAddress(path);
            if (fileAddress[0] == 0||fileAddress[0]==1)
            {
                return disknum;
            }
            if (fileAddress[1] != 64)
            {
                MessageBox.Show("文件夹已存在");
                return disknum;
            }            
            fileAddress[1] = FindItem(fileAddress[0], path[0]);
            if (fileAddress[1] == 64)
            {
                return disknum;
            }
            fileAddress[2] = 2;
            byte[] fat = new byte[128];
            FileStream disk = new FileStream(path[0], FileMode.Open);
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, fat.Length);//读取FAT表
            for (int i = 3; i < 128; i++)
            {
                if (fat[i] == 0)
                {
                    fileAddress[2] = i;
                    fcb.SetAddress(i);
                    break;
                }
            }
            if (fileAddress[2] == 2)
            {
                MessageBox.Show("磁盘已满");
                disk.Close();
                return disknum;
            }
            disk.Seek(fileAddress[2], SeekOrigin.Begin);
            disk.WriteByte(254);//254表示目录
            disk.Close();
            WriteItem(path[0], fileAddress[0], fileAddress[1], fcb);                       
            disknum[0] = 1;
            disknum[1] = fileAddress[2];                        
            return disknum;
        }
        public int [] DeleteMenu(string[] startPath)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int[] disknum = new int[128];
            disknum[0] = 0;
            int[] deleteDisknum=new int[128];
            FCB fcb = new FCB();
            int[] fileAddress =SearchAddress(path);
            if (fileAddress[0] == 0 ||fileAddress[0] == 1)
            {
                return disknum;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件夹不存在");
                return disknum;
            }            
            string[] spath = new string[3];
            spath[0] = path[0];
            if(path[1]!="")
                 spath[1] = path[1] +"\\"+ path[2];
            else
                spath[1] =  path[2];
            for (int i = 0; i < 64; i = i + 8)
            {               
                fcb = ReadItem(path[0], fileAddress[2], i);
                spath[2] = fcb.GetName();
                if (fcb.GetAttribute() == 8)
                {
                    deleteDisknum=DeleteMenu(spath);                    
                }
                else if (fcb.GetAttribute() == 2 || fcb.GetAttribute() == 3 || fcb.GetAttribute() == 4 || fcb.GetAttribute() == 5)
                {
                    spath[2] = spath[2]+"."+fcb.GetType();
                    deleteDisknum=DeleteFile(spath);
                }
                else
                {
                    continue;
                }
                if(deleteDisknum[0]==0)
                {
                    return disknum;
                }
                int k = disknum[0] + 1;
                for(int j=1;j<=deleteDisknum[0];j++)
                {
                    disknum[k] = deleteDisknum[j];
                    k++;
                }
                disknum[0] = disknum[0] + deleteDisknum[0];
            }
            byte[] zero = new byte[64];
            for (int i = 0; i < 64; i++)
                zero[i] = 0;
            FileStream disk = new FileStream(path[0], FileMode.Open);
            disk.Seek(fileAddress[2] * 64, SeekOrigin.Begin);
            disk.Write(zero, 0, 64);
            disk.Seek(fileAddress[2], SeekOrigin.Begin);
            disk.WriteByte(0);
            disk.Close();
            disknum[0]++;
            disknum[disknum[0]] = fileAddress[2];
            DeleteItem(path[0], fileAddress[0], fileAddress[1]);           
            return disknum;
        }
        public int[] CutMenu(string[] startPath,string[] endPath)
        {
            string[] spath = new string[3];
            string[] epath = new string[3];
            for (int i = 0; i < 3; i++)
            {
                spath[i] = startPath[i];
                epath[i] = endPath[i];
            }
            int[] disknum = new int[256];
            disknum[0] = 0;
            if(spath[0]!=epath[0])
            {
                int[] createDisknum=CopyMenu(spath, epath);
                if(createDisknum[0]==0)
                {
                    return disknum;
                }
                
                int []deleteDisknum=DeleteMenu(spath);
                if(deleteDisknum[0]==0)
                {
                    return disknum;
                }
                int k = 0;
                for (int i = 0; i <= deleteDisknum[0]; i++)
                {
                    disknum[k] = deleteDisknum[i];
                    k++;
                }
                for (int i = 0; i <= createDisknum[0]; i++)
                {
                    disknum[k] = createDisknum[i];
                    k++;
                }
                return disknum;
            }
            FCB fcb = new FCB();
            int[] oldFileAddress = SearchAddress(spath);
            if (oldFileAddress[0] == 0 || oldFileAddress[0] == 1)
            {
                return disknum;
            }
            if (oldFileAddress[1] == 64)
            {
                MessageBox.Show("原文件夹不存在");
                return disknum;
            }
            fcb = ReadItem(spath[0], oldFileAddress[0], oldFileAddress[1]);           
            int[] newFileAddress = SearchAddress(epath);
            if (newFileAddress[0] == 0)
            {
                return disknum;
            }
            if (newFileAddress[1] == 64)
            {
                MessageBox.Show("路径不存在");
                return disknum;
            }
            newFileAddress[0] = newFileAddress[2];
            newFileAddress[1]=FindItem(newFileAddress[0], epath[0]);
            if (newFileAddress[1] == 64)
            {
                return disknum;
            }
            WriteItem(epath[0], newFileAddress[0], newFileAddress[1],fcb);
            DeleteItem(spath[0], oldFileAddress[0], oldFileAddress[1]);
            disknum[0] = 255;
            return disknum;
        }
        public int[] CopyMenu(string[] startPath, string[] endPath)
        {
            string[] spath = new string[3];
            string[] epath = new string[3];
            for (int i = 0; i < 3; i++)
            {
                spath[i] = startPath[i];
                epath[i] = endPath[i];
            }
            int[] disknum = new int[128];
            disknum[0] = 0;
            int[] createDisknum = new int[128];
            FCB fcb = new FCB();
            int[] oldFileAddress = SearchAddress(spath);
            if (oldFileAddress[0] == 0 || oldFileAddress[0] == 1)
            {
                return disknum;
            }
            if (oldFileAddress[1] == 64)
            {
                MessageBox.Show("原文件夹不存在");
                return disknum;
            }
            fcb = ReadItem(spath[0], oldFileAddress[0], oldFileAddress[1]);
            string name = fcb.GetName();
            if(epath[2]!="")
            {
               if(epath[1]=="")
                {
                    epath[1] = epath[2];
                }
               else
                {
                    epath[1] = epath[1]+"\\"+epath[2];
                }
            }
            epath[2] = name;
            createDisknum=this.CreatMenu(epath);
            if(createDisknum[0]==0)
            {
                return disknum;
            }
            int k = disknum[0] + 1;
            for (int j = 1; j <= createDisknum[0]; j++)
            {
                disknum[k] = createDisknum[j];
                k++;
            }
            disknum[0] = disknum[0] + createDisknum[0];
            string[] newSpath = new string[3];
            newSpath[0] = spath[0];
            if (spath[1] != "")
                newSpath[1] = spath[1] + "\\" + spath[2];
            else
                newSpath[1] = spath[2];
            for (int i=0;i<64;i=i+8)
            {                 
                fcb =ReadItem(spath[0], oldFileAddress[2],i);
                newSpath[2]  = fcb.GetName();
                if (fcb.GetAttribute()==8)
                {                                       
                    createDisknum=CopyMenu(newSpath, epath);
                }
                else  if(fcb.GetAttribute()==2|| fcb.GetAttribute() == 3 || fcb.GetAttribute() == 4 || fcb.GetAttribute() == 5 )
                {
                    newSpath[2]  = newSpath[2]+"."+ fcb.GetType();                    
                    createDisknum =CopyFile(newSpath, epath);
                }
                else
                {
                    continue;
                }
                if (createDisknum[0] == 0)
                {
                    return disknum;
                }
                k = disknum[0] + 1;
                for (int j = 1; j <= createDisknum[0]; j++)
                {
                    disknum[k] = createDisknum[j];
                    k++;
                }
                disknum[0] = disknum[0] + createDisknum[0];
            }
            return disknum;
        }
        public int EditMenu(string[] startPath, string name)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            FCB fcb = new FCB(0);
            fcb.SetName(name);
            int[] oldFileAddress = SearchAddress(path);
            if (oldFileAddress[0] == 0|| oldFileAddress[0] == 1)
            {
                return 0;
            }
            if (oldFileAddress[1] == 64)
            {
                MessageBox.Show("目录不存在");
                return 0;
            }
            path[2] = name;
            int[] newFileAddress = SearchAddress(path);
            if (newFileAddress[0] == 0||newFileAddress[0] == 1)
            {
                return 0;
            }
            if (newFileAddress[1] != 64)
            {
                MessageBox.Show("目录已存在");
                return 0;
            }
            fcb.SetAddress(oldFileAddress[2]);
            WriteItem(path[0], oldFileAddress[0], oldFileAddress[1],fcb);
            return 1;
        }
        public string ReadContent(string harddisk,int address)
        {
            string content = "";
            byte[] byteContent = new byte[64];
            byte[] fat = new byte[128];
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, fat.Length);//读取FAT表
            while (true)
            {
                if((address>2&&address<128)||(address==253))
                {
                    if (address == 253)
                    {
                        break;
                    }
                    disk.Seek(address * 64, SeekOrigin.Begin);
                    disk.Read(byteContent, 0, 64);
                    content = content + Encoding.Default.GetString(byteContent);
                    address = fat[address];
                }
                else
                {
                    MessageBox.Show("文件内容破坏");
                    disk.Close();
                    return content;
                }                
            }
            disk.Close();
            return content;
        }
        public int[] WriteContent(string harddisk, string content, int address)
        {
            byte[] byteContent = Encoding.Default.GetBytes(content);
            int []contentDisknum = new int[128];
            if(content=="")
            {
                contentDisknum[0] = 1;
            }
            else
            {
                contentDisknum[0] = byteContent.Length / 64;
                if (byteContent.Length % 64 != 0)
                    contentDisknum[0]++;
            }           
            contentDisknum[1] = address;
            byte[] fat = new byte[128];
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, fat.Length);//读取FAT表
            int k = 1;
            int i = 3;
            if (contentDisknum[0] > 1)
            {
                for (; i < 128; i++)
                {
                    if(i==address)
                    {
                        continue;
                    }
                    if (fat[i] == 0)
                    {
                        k++;
                        contentDisknum[k] = i;
                        if (k == contentDisknum[0])
                        {
                            break;
                        }
                    }
                }
                contentDisknum[0] = k;
            }
            contentDisknum[k + 1] = 253;
            if (i == 128)
            {
                MessageBox.Show("磁盘空间不足，部分文件可能丢失");
            }            
            byte[] blockContent = new byte[64];
            for (i = 0; i < contentDisknum[0]-1; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    blockContent[j] = byteContent[i * 64 + j];
                }
                disk.Seek(64 * contentDisknum[i+1], SeekOrigin.Begin);
                disk.Write(blockContent, 0, 64);
            }
            disk.Seek(64 * contentDisknum[i+1], SeekOrigin.Begin);
            if (byteContent.Length-(i+1)*64>=0)
            {
                for (int j = 0; j < 64; j++)
                {
                    blockContent[j] = byteContent[i * 64 + j];
                }
                disk.Write(blockContent, 0, 64);
            }
            else
            {
                for (int j = 0; j < byteContent.Length % 64; j++)
                {
                    blockContent[j] = byteContent[i * 64 + j];
                }
                disk.Write(blockContent, 0, byteContent.Length % 64);
            }
            for (i = 1; contentDisknum[i] != 253; i++)
            {
                disk.Seek(contentDisknum[i], SeekOrigin.Begin);
                disk.WriteByte((byte)contentDisknum[i + 1]);
            }
            disk.Close();
            return contentDisknum;
        }
        public int[] DeleteContent(string harddisk, int address)
        {
            int[] deleteDisknum = new int[128];
            byte[] zero = new byte[64];
            int i =0;
            for (; i < 64; i++)
                zero[i] = 0;
            byte[] fat = new byte[128];
            FileStream disk = new FileStream(harddisk, FileMode.Open);
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, fat.Length);//读取FAT表
            i = 0;
            while (true)
            {
                if ((address > 2 && address < 128) || (address == 253))
                {
                    i++;
                    deleteDisknum[i] = address;                    
                    disk.Seek(address * 64, SeekOrigin.Begin);
                    disk.Write(zero, 0, 64);
                    disk.Seek(address, SeekOrigin.Begin);
                    disk.WriteByte(0);
                    address = fat[address];
                    if (address == 253)
                    {
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("原文件内容破坏");
                    deleteDisknum[0] = i;
                    disk.Close();
                    return deleteDisknum;                   
                }                
            }
            deleteDisknum[0] = i;
            disk.Close();
            return deleteDisknum;
        }
        public int [] CreateFile(string[] startPath, string content, int attribute)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int [] createDisknum = new int[128];
            createDisknum[0] = 0;
            FCB fcb = new FCB();
            int[] fileAddress = SearchAddress(path);
            if (fileAddress[0] == 0|| fileAddress[0] == 1)
            {
                return createDisknum;
            }
            if (fileAddress[1] != 64)
            {
                MessageBox.Show("文件已存在");
                return createDisknum;
            }
            fileAddress[1] =FindItem(fileAddress[0], path[0]);
            if (fileAddress[1] == 64)
            {
                return createDisknum;
            }
            byte[] fat = new byte[128];
            FileStream disk = new FileStream(path[0], FileMode.Open);
            disk.Seek(0, SeekOrigin.Begin);
            disk.Read(fat, 0, fat.Length);//读取FAT表
            disk.Close(); 
            fileAddress[2]= 2;
            for (int i = 3; i < 128; i++)
            {
                if (fat[i] == 0)
                {
                    fileAddress[2] = i;
                    break;
                }
            }
            if (fileAddress[2] == 2)
            {
                MessageBox.Show("磁盘已满");
                return createDisknum;
            }           
            string[] name = path[2].Split(new char[] { '.' });
            if(name.Length!=2)
            {
                MessageBox.Show("文件创建失败");
                return createDisknum;
            }            
            createDisknum = WriteContent(path[0], content, fileAddress[2]);
            fcb.SetName(name[0]);
            fcb.SetType(name[1]);
            fcb.SetAttribute(attribute);
            fcb.SetAddress(fileAddress[2]);
            fcb.SetLength(createDisknum[0]);
            WriteItem(path[0], fileAddress[0], fileAddress[1], fcb);
            return createDisknum;
            
        }
        public int[] DeleteFile(string[] startPath)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int [] deleteDisknum = new int[128];
            deleteDisknum[0] = 0;
            int[] fileAddress = SearchAddress(path);
            if (fileAddress[0] == 0|| fileAddress[0] == 1)
            {
                return deleteDisknum;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件不存在");
                return deleteDisknum;
            }
            deleteDisknum = DeleteContent(path[0], fileAddress[2]);
            if(deleteDisknum[0]==0)
            {
                return deleteDisknum;
            }
            DeleteItem(path[0], fileAddress[0], fileAddress[1]);
            return deleteDisknum;
        }
        public int[] CutFile(string[] startPath,string[] endPath)
        {
            string[] spath = new string[3];
            string[] epath = new string[3];
            for (int i = 0; i < 3; i++)
            {
                spath[i] = startPath[i];
                epath[i] = endPath[i];
            }
            int[] disknum= new int[256];
            disknum[0] = 0;        
            FCB fcb = new FCB();
            int[] oldFileAddress = SearchAddress(spath);
            if (oldFileAddress[0] == 0|| oldFileAddress[0]==1)
            {
                return disknum;
            }
            if (oldFileAddress[1] == 64)
            {
                MessageBox.Show("原文件不存在");
                return disknum;
            }
            fcb = ReadItem(spath[0], oldFileAddress[0], oldFileAddress[1]);
            int[] newMenuAddress = SearchAddress(epath);
            if (newMenuAddress[0] == 0 || oldFileAddress[0] == 1)
            {
                return disknum;
            }
            if (newMenuAddress[1] == 64)
            {
                MessageBox.Show("目的目录不存在");
                return disknum;
            }
            if (epath[2] == ""|| epath[1] == "")
            {
                epath[1] = epath[2];
            }
            else
            {
                epath[1] = epath[1] + "\\" + epath[2];
            }
            epath[2] = spath[2];        
            int[] deleteDisknum = new int[128];
            int[] createDisknum = new int[128];
            if (spath[0] != epath[0])
            {                
                string content = ReadContent(spath[0], fcb.GetAddress());
                createDisknum = CreateFile(epath, content, fcb.GetAttribute());
                if(createDisknum[0]==0)
                {
                    return disknum;
                }
                deleteDisknum = DeleteFile(spath);
                if(deleteDisknum[0]==0)
                {
                    return createDisknum;
                }
                
                int k=0;
                for(int i=0;i<= deleteDisknum[0];i++)
                {
                    disknum[k] = deleteDisknum[i];
                    k++;
                }
                for(int i=0;i<= createDisknum[0];i++)
                {
                    disknum[k] = createDisknum[i];
                    k++;
                }
                return disknum;
            }
            int[] newFileAddress = SearchAddress(epath);
            if (newFileAddress[0] == 0 || newFileAddress[0] == 1)
            {
                return disknum;
            }
            if (newFileAddress[1] != 64)
            {
                MessageBox.Show("目的文件重名");
                return disknum;
            }
            newFileAddress[0] = newMenuAddress[2];
            newFileAddress[1] = FindItem(newFileAddress[0], epath[0]);
            if(newFileAddress[1]==128)
            {
                return disknum;
            }
            WriteItem(epath[0], newFileAddress[0], newFileAddress[1], fcb);
            DeleteItem(spath[0], oldFileAddress[0], oldFileAddress[1]);
            disknum[0] = 255;
            return disknum;
        }
        public int[] CopyFile(string[]startPath,string[] endPath)
        {
            string[] spath = new string[3];
            string[] epath = new string[3];
            for (int i = 0; i < 3; i++)
            {
                spath[i] = startPath[i];
                epath[i] = endPath[i];
            }
            int []fileDisknum = new int[128];
            fileDisknum[0] = 0;
            int[] oldFileAddress = SearchAddress(spath);
            if (oldFileAddress[0] == 0 || oldFileAddress[0] == 1)
            {
                return fileDisknum;
            }
            if (oldFileAddress[1] == 64)
            {
                MessageBox.Show("文件不存在");
                return fileDisknum;
            }           
            string content = ReadContent(spath[0], oldFileAddress[2]);
            FileStream disk = new FileStream(spath[0], FileMode.Open);
            disk.Seek(oldFileAddress[0]*64+ oldFileAddress[1]+5, SeekOrigin.Begin);
            int attribute = disk.ReadByte();
            disk.Close();
            if (epath[2] == ""|| epath[1] == "")
            {
                epath[1] = epath[2];
            }
            else
            {
                epath[1] = epath[1] + "\\" + epath[2];
            }
            epath[2] = spath[2];
            return CreateFile(epath, content, attribute);
           
        }
        public int[] EditFile(string [] startPath, string name,string type,int attribute, string content)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int []fileDisknum = new int[256];
            fileDisknum[0]=0;
            int[] deleteDisknum = new int[128];
            int[] writeDisknum = new int[128];
            string oldFileContent;
            FCB fcb = new FCB();
            int[] fileAddress = SearchAddress(path);
            if (fileAddress[0] == 0 || fileAddress[0] == 1)
            {
                return fileDisknum;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件不存在");
                return fileDisknum;
            }
            oldFileContent = ReadContent(path[0], fileAddress[2]);
            deleteDisknum = DeleteContent(path[0], fileAddress[2]);
            if(deleteDisknum[0]==0)
            {
                return fileDisknum;
            }
            writeDisknum = WriteContent(path[0], content, fileAddress[2]);
            if(writeDisknum[0]==0)
            {
                WriteContent(path[0], oldFileContent, fileAddress[2]);
                return fileDisknum;
            }            
            int k = 0;
            for (int i = 0; i <= deleteDisknum[0]; i++)
            {
                fileDisknum[k] = deleteDisknum[i];
                k++;
            }
            for (int i = 0; i <= writeDisknum[0]; i++)
            {
                fileDisknum[k] = writeDisknum[i];
                k++;
            }
            fcb.SetName(name);
            fcb.SetType(type);
            fcb.SetAttribute(attribute);
            fcb.SetAddress(fileAddress[2]);
            fcb.SetLength(writeDisknum[0]);
            WriteItem(path[0], fileAddress[0], fileAddress[1],fcb);
            return fileDisknum;
        }
        public void EditFile(string[] startPath, string name, string type, int attribute)
        {
            string[] path = new string[3];
            for (int i = 0; i < 3; i++)
                path[i] = startPath[i];
            int[] fileAddress = SearchAddress(path);
            if (fileAddress[0] == 0 || fileAddress[0] == 1)
            {
                return ;
            }
            if (fileAddress[1] == 64)
            {
                MessageBox.Show("文件不存在");
                return ;
            }
            FCB fcb = ReadItem(path[0], fileAddress[0], fileAddress[1]);
            fcb.SetName(name);
            fcb.SetType(type);
            fcb.SetAttribute(attribute);
            WriteItem(path[0], fileAddress[0], fileAddress[1], fcb);
        }
    }
}
