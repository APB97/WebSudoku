export function addListener(dotnetHelper, methodName) {
    window.addEventListener('load', () => {
        dotnetHelper.invokeMethodAsync(methodName, window.innerWidth);
    });

    window.addEventListener('resize', () => {
        dotnetHelper.invokeMethodAsync(methodName, window.innerWidth);
    });
}

export function getDimensions() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

export function removeListener() {
    window.removeEventListener('load', () => {
        dotnetHelper.invokeMethodAsync(methodName, window.innerWidth)
    });

    window.removeEventListener('resize', () => {
        dotnetHelper.invokeMethodAsync(methodName, window.innerWidth)
    })
}