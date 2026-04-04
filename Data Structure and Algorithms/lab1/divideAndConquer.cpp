#include <iostream>
using namespace std;

int findMax(int arr[], int left, int right) {
    if (left == right) {
        return arr[left];
    }

    int mid = left + (right - left) / 2;

    int maxLeft = findMax(arr, left, mid);
    int maxRight = findMax(arr, mid + 1, right);

    return (maxLeft > maxRight) ? maxLeft : maxRight;
}

int findMax(int arr[], int size) {
    return findMax(arr, 0, size - 1);
}

int main() {
    int arr[] = {64, 34, 25, 12, 22, 11, 90};
    int n = sizeof(arr) / sizeof(arr[0]);

    int maxElement = findMax(arr, n);
    cout << "Maximum element: " << maxElement << endl;

    return 0;
}