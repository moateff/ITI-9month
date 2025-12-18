#include <iostream>
using namespace std;

void merge(int arr[], int left, int mid1, int mid2, int right) {
    int lsize = mid1 - left + 1;
    int msize = mid2 - mid1;
    int rsize = right - mid2;

    int* lArr = new int[lsize];
    int* mArr = new int[msize];
    int* rArr = new int[rsize];
    
    for (int i = 0; i < lsize; i++)
        lArr[i] = arr[left + i];
    for (int j = 0; j < msize; j++)
        mArr[j] = arr[mid1 + 1 + j];
    for (int k = 0; k < rsize; k++)
        rArr[k] = arr[mid2 + 1 + k];

    int i = 0, j = 0, k = 0, index = left;

    while (i < lsize && j < msize && k < rsize) {
        if (lArr[i] <= mArr[j] && lArr[i] <= rArr[k]) {
            arr[index++] = lArr[i++];
        } else if (mArr[j] <= lArr[i] && mArr[j] <= rArr[k]) {
            arr[index++] = mArr[j++];
        } else {
            arr[index++] = rArr[k++];
        }
    }

    while (i < lsize && j < msize) {
        if (lArr[i] <= mArr[j]) {
            arr[index++] = lArr[i++];
        } else {
            arr[index++] = mArr[j++];
        }
    }

    while (j < msize && k < rsize) {
        if (mArr[j] <= rArr[k]) {
            arr[index++] = mArr[j++];
        } else {
            arr[index++] = rArr[k++];
        }
    }

    while (i < lsize && k < rsize) {
        if (lArr[i] <= rArr[k]) {
            arr[index++] = lArr[i++];
        } else {
            arr[index++] = rArr[k++];
        }
    }

    while (i < lsize) {
        arr[index++] = lArr[i++];
    }
    while (j < msize) {
        arr[index++] = mArr[j++];
    }
    while (k < rsize) {
        arr[index++] = rArr[k++];
    }

    delete[] lArr;
    delete[] mArr;
    delete[] rArr;
}

void threeWayMergeSort(int arr[], int left, int right) {
    if (left < right) {
        int mid1 = left + (right - left) / 3;
        int mid2 = left + 2 * (right - left) / 3;

        threeWayMergeSort(arr, left, mid1);
        threeWayMergeSort(arr, mid1 + 1, mid2);
        threeWayMergeSort(arr, mid2 + 1, right);

        merge(arr, left, mid1, mid2, right);
    }
}

void threeWayMergeSort(int arr[], int n) {
    threeWayMergeSort(arr, 0, n - 1);
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

    threeWayMergeSort(arr, n);
    cout << "Sorted array: ";
    printArray(arr, n);

    return 0;
}
