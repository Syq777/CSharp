#pragma once
#include <stdio.h>
#include<string>
#include<time.h>
#include<WS2tcpip.h>
#include <Winsock2.h>
using namespace std;
#pragma comment(lib,"Ws2_32.lib")
public ref class Function
{
public:
	Function();
	~Function();
	int scanTCP(int one, int two, int three, int four, int port);
	//int scanUDP(int one, int two, int three, int four, int port);
};
