/**
 * author: Mohamed Atef
 * date: 2025-01-24
 * description: Cookie management functions
 */
/**
 * Sets a cookie with a given name, value, and optional expiration date
 * @param {string} cookieName - Name of the cookie
 * @param {string} cookieValue - Value of the cookie
 * @param {Date} [expiryDate] - Optional expiration date
 */
function setCookie(cookieName, cookieValue, expiryDate) {
    // Validate cookie name
    if (!cookieName) {
        throw new Error("Cookie name is required");
    }

    // Encode cookie name and value to handle special characters
    let cookie = encodeURIComponent(cookieName) + "=" + encodeURIComponent(cookieValue);

    // If expiryDate is provided and is a valid Date object, add expiration
    if (expiryDate instanceof Date) {
        cookie += "; expires=" + expiryDate.toUTCString();
    }

    // Make the cookie accessible across the entire site
    cookie += "; path=/";

    // Save the cookie in the browser
    document.cookie = cookie;
}

/**
 * Retrieves the value of a cookie by its name
 * @param {string} cookieName - Name of the cookie
 * @returns {string|null} Cookie value or null if not found
 */
function getCookie(cookieName) {
    // Validate cookie name
    if (!cookieName) {
        throw new Error("Cookie name is required");
    }

    // Prepare encoded cookie name for matching
    const name = encodeURIComponent(cookieName) + "=";

    // Split all cookies into an array
    const cookies = document.cookie.split("; ");

    // Search for the cookie
    for (let i = 0; i < cookies.length; i++) {
        if (cookies[i].indexOf(name) === 0) {
            // Decode and return the cookie value
            return decodeURIComponent(cookies[i].substring(name.length));
        }
    }

    // Return null if cookie does not exist
    return null;
}

/**
 * Deletes a cookie by setting its expiration date to the past
 * @param {string} cookieName - Name of the cookie
 */
function deleteCookie(cookieName) {
    // Validate cookie name
    if (!cookieName) {
        throw new Error("Cookie name is required");
    }

    // Overwrite the cookie with an expired date
    document.cookie =
        encodeURIComponent(cookieName) +
        "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/";
}

/**
 * Returns a list of all stored cookies as an object
 * @returns {Object} All cookies as key-value pairs
 */
function allCookieList() {
    // Get all cookies as a single string
    const cookies = document.cookie;
    const result = {};

    // If no cookies exist, return empty object
    if (!cookies) {
        return result;
    }

    // Split cookies into individual key-value pairs
    const cookieArray = cookies.split("; ");

    for (let i = 0; i < cookieArray.length; i++) {
        const parts = cookieArray[i].split("=");
        const name = decodeURIComponent(parts[0]);
        const value = decodeURIComponent(parts.slice(1).join("="));

        // Store cookie in result object
        result[name] = value;
    }

    return result;
}

/**
 * Checks whether a cookie exists
 * @param {string} cookieName - Name of the cookie
 * @returns {boolean} True if cookie exists, otherwise false
 */
function hasCookie(cookieName) {
    // Validate cookie name
    if (!cookieName) {
        throw new Error("Cookie name is required");
    }

    // Reuse getCookie to check existence
    return getCookie(cookieName) !== null;
}
