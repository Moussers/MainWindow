#include<Windows.h>
#include <cstdio>
#include"resource.h"

#define IDC_BUTTON 1000

CONST CHAR g_sz_WINDOW_CLASS[] = "My first window";
LRESULT CALLBACK WndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
void CenterWindow(HWND &hwnd);
void UpdateWindowTitle(HWND hwnd, int width, int height, int x, int y);
INT WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevINST, LPSTR lpCmdLine, INT nCmdShow) {
	WNDCLASSEX wClass;
	ZeroMemory(&wClass, sizeof(wClass));
	wClass.style = NULL;
	wClass.cbSize = sizeof(wClass);   //cb_ - Count Bytes;
	wClass.cbClsExtra = 0;
	wClass.cbWndExtra = 0;

	wClass.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON_BITCOIN));
	wClass.hIconSm = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_ICON_PALM));
	/*wClass.hIcon = (HICON)LoadImage(hInstance, "bitcoin.ico", IMAGE_ICON, LR_DEFAULTSIZE, LR_DEFAULTSIZE, LR_LOADFROMFILE);
	wClass.hIconSm = (HICON)LoadImage(hInstance, "palm.ico", IMAGE_ICON, LR_DEFAULTSIZE, LR_DEFAULTSIZE, LR_LOADFROMFILE);*/
	wClass.hCursor = (HCURSOR)LoadImage
	(
		hInstance, 
		"starcraft-original\\Vertical Resize.ani",
		IMAGE_CURSOR,
		LR_DEFAULTSIZE, LR_DEFAULTSIZE,
		LR_LOADFROMFILE
	);
	//wClass.hCursor = LoadCursor(hInstance, MAKEINTRESOURCE(IDC_CURSOR1));
	wClass.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wClass.hInstance = hInstance;
	wClass.lpszClassName = g_sz_WINDOW_CLASS;
	wClass.lpszMenuName = NULL;
	wClass.lpfnWndProc = WndProc;
	if (RegisterClassEx(&wClass) == NULL)
	{
		MessageBox(NULL, "Class registration failed", NULL, MB_OK | MB_ICONINFORMATION);
	};
	int screenWidth = GetSystemMetrics(SM_CXSCREEN);
	int screenHeight = GetSystemMetrics(SM_CYSCREEN);
	int windowWidth = screenWidth * 3 / 4;
	int windowHeight = screenHeight * 3 / 4;
	int posX = screenWidth / 8;
	int posY = screenHeight / 8;
	HWND hwnd = CreateWindowEx(
		NULL,
		g_sz_WINDOW_CLASS,	
		g_sz_WINDOW_CLASS,		
		WS_OVERLAPPEDWINDOW,
		posX, posY,
		windowWidth, windowHeight,
		NULL,
		NULL,		
		hInstance,
		NULL
	);
	if (hwnd == NULL) 
	{
		MessageBox(NULL, "Windows creation failed", NULL, MB_OK | MB_ICONERROR);
		return 0;
	}
	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);
	MSG msg;
	while (GetMessage(&msg, NULL, 0, 0) > 0) 
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
};
LRESULT CALLBACK WndProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	static int width = 0, height = 0, x = 0, y = 0;
	switch(uMsg)
	{
	case WM_CREATE: 
	{
		HWND hButton = CreateWindowEx(
			NULL,					//exSrtyle
			"Button",				//Class
			"Кнопка",				//Title
			WS_CHILD | WS_VISIBLE,	//Style
			10, 10,					//Position
			150, 80,				//Size
			hwnd,					//Parent
			(HMENU)IDC_BUTTON,		//Для главного окна - это RessourceID главного меню, для дочернего окна 
									//(элемента упралвения окна) - это ResourceID дочернего элемента.
			GetModuleHandle(NULL),	//hInstance
			NULL					//????
			);
	}
		break;
	case WM_COMMAND:
	{
		switch (LOWORD(wParam)) 
		{
		case IDC_BUTTON:
			MessageBox(hwnd, "Проверка курсора", "Инфо", MB_OK | MB_ICONINFORMATION);
			break;
		}
		/*HWND hwnd;
		CenterWindow(hwnd);*/
	}
		break;
	case WM_MOVE:
		/*if (hwnd != NULL) {
			x = (int)(short)LOWORD(lParam);
			y = (int)(short)HIWORD(lParam);
			UpdateWindowTitle(hwnd, width, height, x, y);
		}
		break;*/
	case WM_SIZE:
		/*if (hwnd != NULL) {
			width = LOWORD(lParam);
			height = HIWORD(lParam);
			UpdateWindowTitle(hwnd, width, height, x, y);
		}*/
	{
		RECT window_rect = {};
		GetWindowRect(hwnd, &window_rect);
		CONST INT SIZE = 256;
		CHAR sz_title[SIZE] = {};
		wsprintf
		(
			sz_title,
			"%s, Позиция: %ix%i, Размер: %ix%i",
			g_sz_WINDOW_CLASS,
			window_rect.left, window_rect.top,
			window_rect.right - window_rect.left,
			window_rect.bottom - window_rect.top
		);
		SendMessage(hwnd, WM_SETTEXT, 0, (LPARAM)sz_title);
	}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CLOSE:
		DestroyWindow(hwnd);
		break;
	default:
		return DefWindowProc(hwnd, uMsg, wParam, lParam);
	}
	return FALSE;
}
void CenterWindow(HWND &hwnd) {
	RECT workArea;
	SystemParametersInfo(SPI_GETWORKAREA, 0, &workArea, 0);
	int screanWindth = workArea.right - workArea.left;
	int screanHeight = workArea.bottom - workArea.top;
	GetWindowRect(hwnd, &workArea);
	int windowWidth = workArea.right - workArea.left;
	int windowHeight = workArea.bottom - workArea.top;
	int posX = workArea.left + (screanWindth - windowWidth) / 2;
	int posY = workArea.top + (screanHeight - windowHeight) / 2;
	SetWindowPos(hwnd, NULL, posX, posY, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_NOACTIVATE);
}
void UpdateWindowTitle(HWND hwnd, int width, int height, int x, int y) {
	const INT SIZE = 256;
	CHAR sz_title[SIZE]{};
	wsprintf(sz_title, "Положение окна: %i и %i, (размер окна: %i и %i", width, height, x, y);
	SendMessage(hwnd, WM_SETTEXT, 0, (LPARAM)sz_title);
}