export function isFirefox()
{
    return /firefox/i.test(navigator.userAgent) && !/mobile/i.test(navigator.userAgent);
}