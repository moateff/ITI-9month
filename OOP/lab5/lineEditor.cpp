#include <iostream>
#include <conio.h>
#include <windows.h>

#define XOFFSET 45
#define YOFFSET 10
#define BUFFMAX 25

using namespace std;

void gotoxy(int x, int y) {
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void textattr(int i) {
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void hideConsoleCursor() {
    HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_CURSOR_INFO cursorInfo;

    GetConsoleCursorInfo(hOut, &cursorInfo);

    cursorInfo.bVisible = FALSE;
    cursorInfo.dwSize = 1;

    SetConsoleCursorInfo(hOut, &cursorInfo);
}


struct Buffer {
    char arr[BUFFMAX];
    // int startPostion = 0;
    int endPostion = 0;
    int currentPostion = 0;
};

int isFull(Buffer* buffer) {
    return buffer->endPostion >= BUFFMAX;
}

void printBuffer(Buffer* buffer) {
    cout << "Buffer content: ";
    for(int i = 0; i < buffer->endPostion; i++)
        cout << buffer->arr[i];
}

void refresh(Buffer* buffer) {
    gotoxy(XOFFSET, YOFFSET);
    textattr(112);

    // Clear line
    for (int i = 0; i < BUFFMAX + 2; i++)
        cout << " ";


    // Draw characters
    gotoxy(XOFFSET + 1, YOFFSET);
    for (int i = 0; i < buffer->endPostion; i++) {
        if (i == buffer->currentPostion)
            cout << "_";

        cout << buffer->arr[i];
    }

    // If cursor is at the end, print it here
    if (buffer->currentPostion == buffer->endPostion)
        cout << "_";

    // Put cursor in correct place
    gotoxy(XOFFSET + 1 + buffer->currentPostion, YOFFSET);
    textattr(7);
}

void insertKey(Buffer* buffer, char key){
    if (buffer->endPostion >= BUFFMAX) return;

    // Shift right
    for (int i = buffer->endPostion; i > buffer->currentPostion; --i)
        buffer->arr[i] = buffer->arr[i - 1];

    // Insert
    buffer->arr[buffer->currentPostion] = key;
    buffer->endPostion++;
    buffer->currentPostion++;

    refresh(buffer);
}

void leftArrow(Buffer* buffer){
    if (buffer->currentPostion > 0)
        buffer->currentPostion--;

    refresh(buffer);
}

void rightArrow(Buffer* buffer){
    if (buffer->currentPostion < buffer->endPostion)
        buffer->currentPostion++;

    refresh(buffer);
}

void homeKey(Buffer* buffer){
    buffer->currentPostion = 0;
    refresh(buffer);
}

void endKey(Buffer* buffer){
    buffer->currentPostion = buffer->endPostion;
    refresh(buffer);
}

void backspaceKey(Buffer* buffer) {
    if (buffer->currentPostion > 0) {
        // Shift everything left from the cursor
        for (int i = buffer->currentPostion - 1; i < buffer->endPostion - 1; i++)
            buffer->arr[i] = buffer->arr[i + 1];

        buffer->endPostion--;
        buffer->currentPostion--;
        refresh(buffer);
    }
}

void deleteKey(Buffer* buffer) {
    if (buffer->currentPostion < buffer->endPostion) {
        // Shift everything left starting at cursor
        for (int i = buffer->currentPostion; i < buffer->endPostion - 1; i++)
            buffer->arr[i] = buffer->arr[i + 1];

        buffer->endPostion--;
        refresh(buffer);
    }
}

int main() {
    hideConsoleCursor();

    char key;
    Buffer buffer;
    refresh(&buffer);

    do {
        key = _getch();

        if (key == -32) {  // Special key
            key = _getch();
            switch (key) {
                case 75: leftArrow(&buffer); break;  // LEFT ARROW
                case 77: rightArrow(&buffer); break; // RIGHT ARROW
                case 71: homeKey(&buffer); break;    // HOME
                case 79: endKey(&buffer); break;     // END
                case 83: deleteKey(&buffer); break;  // DELETE
            }
        }
        else {
            if (key == 13) break;        // ENTER
            else if (key == 27) break;   // ESC
            else if (key == 8)           // BACKSPACE
                backspaceKey(&buffer);
            else if (!isFull(&buffer))
                insertKey(&buffer, key);
        }

    } while (true);

    textattr(7);
    gotoxy(0, YOFFSET * 2);
    printBuffer(&buffer);

    return 0;
}
