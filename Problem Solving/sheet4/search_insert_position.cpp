#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        int low = 0;
        int high = nums.size() - 1;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;

            if (nums[mid] < target) {
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
    int target;

    nums = {1, 3, 5, 6};
    target = 5;
    cout << solution.searchInsert(nums, target) << endl;

    nums = {1, 3, 5, 6};
    target = 2;
    cout << solution.searchInsert(nums, target) << endl;

    nums = {1, 3, 5, 6};
    target = 7;
    cout << solution.searchInsert(nums, target) << endl;
    return 0;
}