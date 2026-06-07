#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    int minSubArrayLen(int target, vector<int>& nums) {
        int size = nums.size();

        int sum = 0;
        int ans = INT_MAX;

        int left = 0;

        for (int right = 0; right < size; right++) {
            sum += nums[right];

            while (sum >= target) {
                ans = min(ans, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return ans == INT_MAX ? 0 : ans;
    }
};

int main() {
    Solution solution;

    vector<int> nums;
    int target;

    nums = {2, 3, 1, 2, 4, 3};
    target = 7;
    cout << solution.minSubArrayLen(target, nums) << endl;

    nums = {1, 4, 4};
    target = 4;
    cout << solution.minSubArrayLen(target, nums) << endl;

    nums = {1, 1, 1, 1, 1, 1, 1, 1};
    target = 11;
    cout << solution.minSubArrayLen(target, nums) << endl;

    nums = {1, 2, 3, 4, 5};
    target = 11;
    cout << solution.minSubArrayLen(target, nums) << endl;
    return 0;
}