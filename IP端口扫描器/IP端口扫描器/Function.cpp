#include "Function.h"
Function::Function()
{
}
Function::~Function()
{
}
///*
//������״̬
int Function::scanTCP(int one, int two, int three, int four, int port)
{
	string sip = to_string(one);
	sip = sip + "." + to_string(two) + "." + to_string(three) + "." + to_string(four);
	char ip[16];
	strcpy(ip, sip.c_str());

	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);//ʹ��winsock����֮ǰ��������WSAStartup������װ�벢��ʼ����̬���ӿ�
	
	SOCKET TryConnect = socket(AF_INET, SOCK_STREAM, 0);//��ʼ���׽���
	// AF_INET         IPv4��������
	//SOCK_STREAM     ���򡢿ɿ���˫������������ֽ����׽��� 
	//0               ѡ��type���Ͷ�Ӧ��Ĭ��Э��  

	unsigned long mode = 1;  //ioctlsocket���������һ������
	ioctlsocket(TryConnect, FIONBIO, &mode);  //����Ϊ������ģʽ
	//��ʶ�׽ӿڵ�������    //���׽ӿڵĲ�������    //ָ�������������������ָ��
	//FIONBIO:������ֹ�׽ӿڵķ�����ģʽ
	//mode �����0  ��ֹ0
	
	/*
	sockaddr_in addr_local; //Դ�׽��ֵĵ�ַ
	addr_local.sin_family = AF_INET;//Э����
	inet_pton(AF_INET, INADDR_ANY, &(addr_local.sin_addr.S_un.S_addr));//�洢IP��ַ
	addr_local.sin_port = htons(58888);	//�洢�˿ں�
	int a=bind(TryConnect, (SOCKADDR*)&addr_local, sizeof(SOCKADDR));
	if (a == 0)  return -2;
	*/

	sockaddr_in addr; //Ŀ���׽��ֵĵ�ַ
	addr.sin_family = AF_INET;//Э����
	inet_pton(AF_INET, ip, &(addr.sin_addr.S_un.S_addr));//IP��ַת������:�洢IP��ַ
	//addr.sin_addr.S_un.S_addr = inet_addr(ip);  //�ɰ汾
	addr.sin_port = htons(port);	//�洢�˿ں�
	connect(TryConnect, (sockaddr*)&addr, sizeof(sockaddr_in));//����
																																																																																																																																																											
	FD_SET mask;//select()�������ṩһ�ֵ����ݽṹ long��������
	FD_ZERO(&mask);//��mask����ʹ�����в����κ�fd
	FD_SET(TryConnect, &mask);//��fd����mask����
	TIMEVAL TimeOut;
	TimeOut.tv_sec = 0;
	TimeOut.tv_usec = 1000000; //��ʱʱ��Ϊ1000ms
	int retCon = select(0, NULL, &mask, NULL, &TimeOut);  //��ѯ��д��״̬
	//�����������ļ��������ķ�Χ  //ָ��һ��ȴ��ɶ��Լ����׽ӿ�     
	//ָ��һ��ȴ���д�Լ����׽ӿ�    //ָ��һ��ȴ���������׽ӿ�  
	//���ȴ�ʱ��

	closesocket(TryConnect);
	WSACleanup();//�ͷŶ�̬���ӿⲢ�ͷű��������׽���
	return retCon;
}
//*/


/*
//����״̬
int Function::scanTCP(int one, int two, int three, int four, int port)
{
	string sip = to_string(one);
	sip = sip + "." + to_string(two) + "." + to_string(three) + "." + to_string(four);
	char ip[16];
	strcpy(ip, sip.c_str());

	WSADATA wsaData;
	WSAStartup(MAKEWORD(2, 2), &wsaData);//ʹ��winsock����֮ǰ��������WSAStartup������װ�벢��ʼ����̬���ӿ�
	SOCKET TryConnect = socket(AF_INET, SOCK_STREAM, 0);//��ʼ���׽���
	// AF_INET         IPv4��������
	//SOCK_STREAM     ���򡢿ɿ���˫������������ֽ����׽��� 
	//0               ѡ��type���Ͷ�Ӧ��Ĭ��Э��  

	sockaddr_in addr; //Ŀ���׽��ֵĵ�ַ
	addr.sin_family = AF_INET;//Э����
	inet_pton(AF_INET, ip, &(addr.sin_addr.S_un.S_addr));//IP��ַת������:�洢IP��ַ
	//addr.sin_addr.S_un.S_addr = inet_addr(ip);  //�ɰ汾
	addr.sin_port = htons(port);	//�洢�˿ں�
	int retCon = connect(TryConnect, (sockaddr*)&addr, sizeof(sockaddr_in));//����
	closesocket(TryConnect);
	WSACleanup();//�ͷŶ�̬���ӿⲢ�ͷű��������׽���
	return retCon;
}
*/














































