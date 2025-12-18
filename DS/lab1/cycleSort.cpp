#include <iostream>
using namespace std;

void swap(int& x, int& y) {
    int temp = x;
    x = y;
    y = temp;
}

void cycleSort(int arr[], int n) {
    for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++) {
        int item = arr[cycle_start];
        int pos = cycle_start;

        for (int i = cycle_start + 1; i < n; i++) {
            if (arr[i] < item) {
                pos++;
            }
        }

        if (pos == cycle_start) {
            continue;
        }

        while (item == arr[pos]) {
            pos++;
        }

        if (pos != cycle_start) {
            swap(item, arr[pos]);
        }

        while (pos != cycle_start) {
            pos = cycle_start;

            for (int i = cycle_start + 1; i < n; i++) {
                if (arr[i] < item) {
                    pos++;
                }
            }

            while (item == arr[pos]) {
                pos++;
            }

            if (item != arr[pos]) {
                swap(item, arr[pos]);
            }
        }
    }
}

void printArray(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

int main() {
    int arr[] = {64, 34, 25, 12, 22, 11, 90};
    int n = sizeof(arr) / sizeof(arr[0]);

    cycleSort(arr, n);
    cout << "Sorted array: ";
    printArray(arr, n);

    return 0;
}