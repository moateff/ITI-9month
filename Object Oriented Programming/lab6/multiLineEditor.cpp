#include <iostream>
#include <conio.h>
#include <windows.h>

using namespace std;

void gotoxy(int x, int y) {
    COORD coord = {SHORT(x), SHORT(y)};
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void clearScreen() {
    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_SCREEN_BUFFER_INFO csbi;
    DWORD count, cellCount;
    COORD homeCoords = {0, 0};

    if (hConsole == INVALID_HANDLE_VALUE) return;

    if (!GetConsoleScreenBufferInfo(hConsole, &csbi)) return;
    cellCount = csbi.dwSize.X * csbi.dwSize.Y;

    FillConsoleOutputCharacter(hConsole, (TCHAR)' ', cellCount, homeCoords, &count);
    FillConsoleOutputAttribute(hConsole, csbi.wAttributes, cellCount, homeCoords, &count);

    SetConsoleCursorPosition(hConsole, homeCoords);
}

struct Buffer {
    char* arr;
    int length;
    int endPosition;
    int currentPosition;
    int xPosition;
    int yPosition;
};

void initBuffer(Buffer* buffer, int length, int x, int y) {
    buffer->arr = new char[length + 1];
    buffer->length = length;
    buffer->endPosition = 0;
    buffer->currentPosition = 0;
    buffer->xPosition = x;
    buffer->yPosition = y;
    buffer->arr[0] = '\0';
}

void cleanBuffer(Buffer* buffer) {
    if (buffer->arr != nullptr) {
        delete[] buffer->arr;   
        buffer->arr = nullptr;    
    }

    buffer->length = 0;
    buffer->endPosition = 0;
    buffer->currentPosition = 0;
    buffer->xPosition = 0;
    buffer->yPosition = 0;
}

void redraw(Buffer* buffer) {
    gotoxy(buffer->xPosition, buffer->yPosition);
    for (int i = 0; i < buffer->length; i++) {
        if (i < buffer->endPosition) cout << buffer->arr[i];
        else cout << " ";
    }
    gotoxy(buffer->xPosition + buffer->currentPosition, buffer->yPosition);
}

void insertKey(Buffer* buffer, char key){
    if (buffer->endPosition >= buffer->length) return;

    for (int i = buffer->endPosition; i > buffer->currentPosition; i--)
        buffer->arr[i] = buffer->arr[i-1];

    buffer->arr[buffer->currentPosition] = key;
    buffer->currentPosition++;
    buffer->endPosition++;

    buffer->arr[buffer->endPosition] = '\0';

    redraw(buffer);
}

void backspaceKey(Buffer* buffer) {
    if (buffer->currentPosition == 0) return;

    for (int i = buffer->currentPosition - 1; i < buffer->endPosition - 1; i++)
        buffer->arr[i] = buffer->arr[i + 1];

    buffer->currentPosition--;
    buffer->endPosition--;

    buffer->arr[buffer->endPosition] = '\0';

    redraw(buffer);
}

void deleteKey(Buffer* buffer) {
    if (buffer->currentPosition >= buffer->endPosition) return;

    for (int i = buffer->currentPosition; i < buffer->endPosition - 1; i++)
        buffer->arr[i] = buffer->arr[i + 1];

    buffer->endPosition--;

    buffer->arr[buffer->endPosition] = '\0';

    redraw(buffer);
}

void leftArrow(Buffer* buffer) {
    if (buffer->currentPosition > 0) buffer->currentPosition--;
    gotoxy(buffer->xPosition + buffer->currentPosition, buffer->yPosition);
}

void rightArrow(Buffer* buffer) {
    if (buffer->currentPosition < buffer->endPosition) buffer->currentPosition++;
    gotoxy(buffer->xPosition + buffer->currentPosition, buffer->yPosition);
}

void homeKey(Buffer* buffer){
    buffer->currentPosition = 0;
    gotoxy(buffer->xPosition + buffer->currentPosition, buffer->yPosition);
}

void endKey(Buffer* buffer){
    buffer->currentPosition = buffer->endPosition;
    gotoxy(buffer->xPosition + buffer->currentPosition, buffer->yPosition);
}

int handleUserInput(char key, Buffer* buffers, int& currentLine, int lineNum, char startRange, char endRange) {
    Buffer* buf = &buffers[currentLine];

    if (key == -32) {
        char special = _getch();
        switch(special) {
            case 75: leftArrow(buf); break; // LEFT
            case 77: rightArrow(buf); break; // RIGHT
            case 72: if(currentLine > 0) currentLine--; break; // UP
            case 80: if(currentLine < lineNum - 1) currentLine++; break; // DOWN
            case 71: homeKey(buf); break;   // HOME
            case 79: endKey(buf); break;   // END
            case 83: deleteKey(buf); break; // DELETE
        }
        return 0;
    }

    if (key == 13) { // ENTER
        if(currentLine < lineNum - 1) {
            currentLine++;
            return 0;
        } else {
            return 1;
        }
    }

    if (key == 9) { // TAB 
        currentLine = (currentLine + 1) % lineNum;
        return 0;
    }

    if (key == 27) return 1; // ESC

    if (key == 8) backspaceKey(buf);
    else if(key >= startRange && key <= endRange) insertKey(buf, key);

    return 0;
}

char** multiLineEditor(int* xPosition, int* yPosition, int* length, char* startRange, char* endRange, int lineNum) {
    Buffer* buffers = new Buffer[lineNum];

    for(int i = 0; i < lineNum; i++)
        initBuffer(&buffers[i], length[i], xPosition[i], yPosition[i]);

    int currentLine = 0;

    while(true) {
        gotoxy(buffers[currentLine].xPosition + buffers[currentLine].currentPosition,
               buffers[currentLine].yPosition);
        char key = _getch();
        if(handleUserInput(key, buffers, currentLine, lineNum, startRange[currentLine], endRange[currentLine])) break;
    }

    char** result = new char*[lineNum];
    for(int i = 0; i < lineNum; i++) {
        result[i] = new char[buffers[i].endPosition + 1];
        strcpy(result[i], buffers[i].arr);
        cleanBuffer(&buffers[i]);
    }
    delete[] buffers;

    return result;
}
/*
int main() {
    clearScreen();

    int x[] = {10, 10, 10};
    int y[] = {5, 6, 7};
    int len[] = {30, 30, 30};
    char startRange[] = {'a', '1', 'A'};
    char endRange[] = {'z', '9', 'Z'};
    int lines = 3;

    char** text = multiLineEditor(x, y, len, startRange, endRange, lines);

    clearScreen();

    for(int i = 0; i < lines; i++)
        cout << "Line " << i+1 << ": " << text[i] << endl;

    for(int i = 0; i < lines; i++) delete[] text[i];
    delete[] text;

    return 0;
}
*/