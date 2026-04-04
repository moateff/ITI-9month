const video = document.querySelector(".video");

const playBtn = document.querySelector(".play-button");
const stopBtn = document.querySelector(".stop-button");
const startBtn = document.querySelector(".start-button");
const endBtn = document.querySelector(".end-button");
const forwardBtn = document.querySelector(".forward-button");
const backwardBtn = document.querySelector(".backward-button");
const muteBtn = document.querySelector(".mute-button");

const timeMax = document.querySelector(".time-max");
const timeStamp = document.querySelector(".time-stamp");

const timeRange = document.querySelector(".time-range");
const soundRange = document.querySelector(".sound-range");
const speedRange = document.querySelector(".speed-range");

function formatTime(time) {
    const min = Math.floor(time / 60);
    const sec = Math.floor(time % 60).toString().padStart(2, "0");
    return `${min}:${sec}`;
}

// Load metadata
video.addEventListener("loadedmetadata", () => {
    timeRange.min = 0;
    timeRange.max = video.duration;
    timeRange.step = 1;
    timeRange.value = 0;

    timeMax.innerText = formatTime(video.duration);
});

// Update UI
video.addEventListener("timeupdate", () => {
    timeRange.value = video.currentTime;
    timeStamp.innerText = formatTime(video.currentTime);
});

// Controls
playBtn.onclick = () => video.play();

stopBtn.onclick = () => video.pause();

startBtn.onclick = () => video.currentTime = 0;

endBtn.onclick = () => video.currentTime = video.duration;

forwardBtn.onclick = () => video.currentTime += 10;

backwardBtn.onclick = () => video.currentTime -= 10;

muteBtn.onclick = () => video.muted = !video.muted;

// Sliders
timeRange.oninput = () => {
    video.currentTime = timeRange.value;
}

soundRange.min = 0;
soundRange.max = 100;
soundRange.value = 100;

soundRange.oninput = () => {
    video.volume = soundRange.value / 100;
}

speedRange.min = 0.25;
speedRange.max = 4;
speedRange.step = 0.25;
speedRange.value = 1;

speedRange.oninput = () => {
    video.playbackRate = speedRange.value;
}
