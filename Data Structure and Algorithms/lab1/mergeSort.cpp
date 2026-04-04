#include <iostream>
using namespace std;

void merge(int arr[], int left, int mid, int right) {
    int lsize = mid - left + 1;
    int rsize = right - mid;

    int* lArr = new int[lsize];
    int* rArr = new int[rsize];

    for (int i = 0; i < lsize; i++)
        lArr[i] = arr[left + i];
    for (int j = 0; j < rsize; j++)
        rArr[j] = arr[mid + 1 + j];

    int i = 0, j = 0, k = left;
    while (i < lsize && j < rsize) {
        if (lArr[i] <= rArr[j]) {
            arr[k] = lArr[i];
            i++;
        } else {
            arr[k] = rArr[j];
            j++;
        }
        k++;
    }

    while (i < lsize) {
        arr[k] = lArr[i];
        i++;
        k++;
    }

    while (j < rsize) {
        arr[k] = rArr[j];
        j++;
        k++;
    }

    delete[] lArr;
    delete[] rArr;
}

void mergeSort(int arr[], int left, int right) {
    if (left < right) {
        int mid = left + (right - left) / 2;

        mergeSort(arr, left, mid);
        mergeSort(arr, mid + 1, right);

        merge(arr, left, mid, right);
    }
}

void mergeSort(int arr[], int n) {
    mergeSort(arr, 0, n - 1);
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

    mergeSort(arr, n);
    cout << "Sorted array: ";
    printArray(arr, n);

    return 0;
}