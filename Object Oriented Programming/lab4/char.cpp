#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
    while (true)
    {
        int key = _getch();

        if (key == 0 || key == 224)
        {
            key = _getch();
            switch (key)
            {
                case 75: cout << "[LEFT]\n"; break;
                case 77: cout << "[RIGHT]\n"; break;
                case 72: cout << "[UP]\n"; break;
                case 80: cout << "[DOWN]\n"; break;
                default: cout << "[OTHER SPECIAL: " << key << "]\n"; break;
            }
        }
        else
        {
            cout << "[CHAR: " << key << "]\n";
        }
    }
}

