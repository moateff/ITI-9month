import java.util.Arrays;

public static float PresentList(float budget, float bagVolume, int people,
                                int Npresents, float[] presentVolume, float[] presentPrice) {
    if (people == 0 || Npresents == 0) return 0.0f;

    // Scale float volumes to integers (assumes at most 2 decimal places)
    final int SCALE = 100;
    int V = (int) (bagVolume * SCALE);

    // dp[k][v] = max total price with (count % people == k) and total volume == v
    // A value of -1.0f means this state is unreachable
    float[][] dp = new float[people][V + 1];
    for (float[] row : dp) Arrays.fill(row, -1.0f);
    dp[0][0] = 0.0f; // Base case: 0 items, 0 volume, 0 cost

    // Process each present (0/1 knapsack - one copy per present)
    for (int i = 0; i < Npresents; i++) {
        int vol = Math.round(presentVolume[i] * SCALE);
        float price = presentPrice[i];

        // Skip presents that don't even fit alone
        if (vol > V) continue;

        // Use a fresh copy so each present is only used once
        float[][] ndp = new float[people][V + 1];
        for (float[] row : ndp) Arrays.fill(row, -1.0f);

        for (int k = 0; k < people; k++) {
            for (int v = 0; v <= V; v++) {
                if (dp[k][v] < 0) continue; // State unreachable, skip

                // Option 1: Don't take present i
                if (ndp[k][v] < dp[k][v])
                    ndp[k][v] = dp[k][v];

                // Option 2: Take present i
                int nv = v + vol;
                if (nv <= V) {
                    int nk = (k + 1) % people;
                    float np = dp[k][v] + price;
                    if (ndp[nk][nv] < np)
                        ndp[nk][nv] = np;
                }
            }
        }
        dp = ndp;
    }

    // Find the maximum affordable spend where count is divisible by people
    float result = 0.0f;
    for (int v = 0; v <= V; v++) {
        // dp[0][v] means count % people == 0, i.e., count is a valid multiple
        if (dp[0][v] >= 0 && dp[0][v] <= budget + 1e-6f) {
            result = Math.max(result, dp[0][v]);
        }
    }
    return result;
}
