#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int findPeakElement(vector<int>& nums) {
        int size = nums.size();

        int low = 0;
        int high = size - 1;

        while (low <= high) {
            int mid = low + (high - low) / 2;

            if (mid + 1 < size && nums[mid + 1] > nums[mid]) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        
        return low;
    }
};

int main() {
    Solution solution;

    vector<int> nums;

    nums = {1, 2, 1, 3, 5, 6, 4};
    cout << solution.findPeakElement(nums) << endl;

    nums = {1, 2, 3, 1};
    cout << solution.findPeakElement(nums) << endl;

    nums = {1};
    cout << solution.findPeakElement(nums) << endl;

    nums = {1, 2};
    cout << solution.findPeakElement(nums) << endl;

    return 0;
}