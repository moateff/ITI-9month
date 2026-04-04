#include <iostream>
using namespace std;

int* twoSum(int arr[], int n, int target) {
    int left = 0;
    int right = n - 1;

    while (left < right) {
        int sum = arr[left] + arr[right];
        if (sum == target) {
            return new int[2]{left, right};
        } else if (sum < target) {
            left++;
        } else {
            right--;
        }
    }
    return nullptr;
}

int main() {
    int arr[] = {1, 2, 3, 4, 6};
    int n = sizeof(arr) / sizeof(arr[0]);
    int target = 9;

    int* result = twoSum(arr, n, target);
    if (result) {
        cout << "Pair found at indices: " << result[0] << ", " << result[1] << endl
             << "Values: " << arr[result[0]] << ", " << arr[result[1]] << endl;
        delete[] result;
    } else {
        cout << "No pair found." << endl;
    }

    return 0;
}