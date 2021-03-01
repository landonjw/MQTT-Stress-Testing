import time

tick_delay_ms = 25

class Task:
    def __init__(self, methodToRun, interval_ticks, iterations):
        self.methodToRun = methodToRun
        self.iterations = iterations
        self.interval_ticks = interval_ticks
        self.ticks_remaining = 0
        self.expired = False

    def tick(self):
        self.ticks_remaining = max(0, self.ticks_remaining - 1)
        if self.ticks_remaining == 0:
            self.methodToRun()
            self.iterations = self.iterations - 1
            if self.iterations > 0:
                self.ticks_remaining = self.interval_ticks
            else:
                self.expired = True

tasks = []

def add_task(task):
    tasks.append(task)

def convertMsToTicks(time_ms):
    time_ticks = time_ms // 25
    return time_ticks

def start(onComplete):
    while len(tasks) != 0:
        for task in tasks:
            task.tick()
            if task.expired:
                tasks.remove(task)
        time.sleep(tick_delay_ms / 1_000)
    onComplete()