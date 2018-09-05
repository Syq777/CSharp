#include "Function.h"
Function::Function()
{
}
Function::~Function()
{
}
///*
//非阻塞状态
int Function::scanTCP(int one, int two, int three, int four, int port)
{
	string sip = to_string(one);
	sip = sip + "." + to_string(two) + "." + to_string(three) + "." + to_string(four);
	char ip[16];
	strcpy(ip, sip.c_str());

	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);//使用winsock函数之前，必须用WSAStartup函数来装入并初始化动态连接库
	
	SOCKET TryConnect = socket(AF_INET, SOCK_STREAM, 0);//初始化套接字
	// AF_INET         IPv4因特网域
	//SOCK_STREAM     有序、可靠、双向的面向连接字节流套接字 
	//0               选择type类型对应的默认协议  

	unsigned long mode = 1;  //ioctlsocket函数的最后一个参数
	ioctlsocket(TryConnect, FIONBIO, &mode);  //设置为非阻塞模式
	//标识套接口的描述字    //对套接口的操作命令    //指向操作命令所带参数的指针
	//FIONBIO:允许或禁止套接口的非阻塞模式
	//mode 允许非0  禁止0
	
	/*
	sockaddr_in addr_local; //源套接字的地址
	addr_local.sin_family = AF_INET;//协议族
	inet_pton(AF_INET, INADDR_ANY, &(addr_local.sin_addr.S_un.S_addr));//存储IP地址
	addr_local.sin_port = htons(58888);	//存储端口号
	int a=bind(TryConnect, (SOCKADDR*)&addr_local, sizeof(SOCKADDR));
	if (a == 0)  return -2;
	*/

	sockaddr_in addr; //目的套接字的地址
	addr.sin_family = AF_INET;//协议族
	inet_pton(AF_INET, ip, &(addr.sin_addr.S_un.S_addr));//IP地址转换函数:存储IP地址
	//addr.sin_addr.S_un.S_addr = inet_addr(ip);  //旧版本
	addr.sin_port = htons(port);	//存储端口号
	connect(TryConnect, (sockaddr*)&addr, sizeof(sockaddr_in));//连接
																																																																																																																																																											
	FD_SET mask;//select()机制中提供一种的数据结构 long类型数组
	FD_ZERO(&mask);//将mask清零使集合中不含任何fd
	FD_SET(TryConnect, &mask);//将fd加入mask集合
	TIMEVAL TimeOut;
	TimeOut.tv_sec = 0;
	TimeOut.tv_usec = 1000000; //超时时间为1000ms
	int retCon = select(0, NULL, &mask, NULL, &TimeOut);  //查询可写入状态
	//集合中所有文件描述符的范围  //指向一组等待可读性检查的套接口     
	//指向一组等待可写性检查的套接口    //指向一组等待错误检查的套接口  
	//最多等待时间

	closesocket(TryConnect);
	WSACleanup();//释放动态连接库并释放被创建的套接字
	return retCon;
}
//*/


/*
//阻塞状态
int Function::scanTCP(int one, int two, int three, int four, int port)
{
	string sip = to_string(one);
	sip = sip + "." + to_string(two) + "." + to_string(three) + "." + to_string(four);
	char ip[16];
	strcpy(ip, sip.c_str());

	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);//使用winsock函数之前，必须用WSAStartup函数来装入并初始化动态连接库
	SOCKET TryConnect = socket(AF_INET, SOCK_STREAM, 0);//初始化套接字
	// AF_INET         IPv4因特网域
	//SOCK_STREAM     有序、可靠、双向的面向连接字节流套接字 
	//0               选择type类型对应的默认协议  

	sockaddr_in addr; //目的套接字的地址
	addr.sin_family = AF_INET;//协议族
	inet_pton(AF_INET, ip, &(addr.sin_addr.S_un.S_addr));//IP地址转换函数:存储IP地址
	//addr.sin_addr.S_un.S_addr = inet_addr(ip);  //旧版本
	addr.sin_port = htons(port);	//存储端口号
	int retCon = connect(TryConnect, (sockaddr*)&addr, sizeof(sockaddr_in));//连接
	closesocket(TryConnect);
	WSACleanup();//释放动态连接库并释放被创建的套接字
	return retCon;
}
*/














































