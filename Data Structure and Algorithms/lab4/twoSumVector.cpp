#include <iostream>
#include <vector>
using namespace std;

vector<int> twoSum(vector<int>& numbers, int target) {
    int left = 0;
    int right = numbers.size() - 1;

    while (left < right) {
        int sum = numbers[left] + numbers[right];
        if (sum == target) {
            return {left, right};
        } else if (sum < target) {
            left++;
        } else {
            right--;
        }
    }
    return {};
}

int main() {
    vector<int> numbers = {1, 2, 3, 4, 6};
    int target = 9;

    vector<int> result = twoSum(numbers, target);
    if (!result.empty()) {
        cout << "Pair found at indices: " << result[0] << ", " << result[1] << endl
             << "Values: " << numbers[result[0]] << ", " << numbers[result[1]] << endl;
    } else {
        cout << "No pair found." << endl;
    }

    return 0;
}