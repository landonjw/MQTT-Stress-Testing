import time

tick_delay_ms = 25

class Task:
    """
    Represents an action to invoke at a specified interval.

    Attributes
    ----------
    methodToRun: Function
        The method to run on interval
    interval_ticks: Integer
        The interval to run invoke task at. Must be above 0
    iterations: Integer
        The number of iterations the task should be run for. Must be above 0
    expired: Boolean
        If the task has completed all it's iterations.
        If a task is expired, it will no longer execute the encapsulated method.
    """
    def __init__(self, methodToRun, interval_ticks, iterations):
        self.__validate_task_props(methodToRun, interval_ticks, iterations)
        self.methodToRun = methodToRun
        self.iterations = iterations
        self.interval_ticks = interval_ticks
        self.__ticks_remaining = 0
        self.expired = False

    def __tick(self):
        """
        Executes task if it should on the given tick.
        If the task is executed and fulfills it's interval requirement, it will expire and no longer run.
        Invoked every tick by the task manager.
        """
        self.__ticks_remaining = max(0, self.__ticks_remaining - 1)
        if self.__ticks_remaining == 0:
            self.methodToRun()
            self.iterations = self.iterations - 1
            if self.iterations > 0:
                self.__ticks_remaining = self.interval_ticks
            else:
                self.expired = True

    def __validate_task_props(self, methodToRun, interval_ticks, iterations):
        """
        Validates the properties coming into the Task upon initialization.

        Arguments
        ---------
        methodToRun: Function
            The method to run on interval
        interval_ticks: Integer
            The interval to run invoke task at. Must be above 0
        iterations: Integer
            The number of iterations the task should be run for. Must be above 0
        """
        if methodToRun == None:
            raise ValueError("method must not be null")
        if interval_ticks <= 0:
            raise ValueError("interval must be above 0")
        if iterations <= 0:
            raise ValueError("iterations must be above 0")

tasks = []
running = False

def add_task(task):
    """
    Adds a task to the task manager.
    Tasks should not be added to the task manager after it has started running.

    Arguments
    ---------
    task: Task
        The task to add to the task manager.

    Raises
    ------
    RuntimeException
        If a task is added when the task manager has been started
    """
    if running == True:
        raise RuntimeError("tasks cannot be added to the task manager after it has started running")
    tasks.append(task)

def convertMsToTicks(time_ms):
    """
    Converts milliseconds to ticks.

    Arguments
    ---------
    time_ms: Integer
        The time in milliseconds

    Returns
    -------
    Integer
        The time in ticks
    """
    time_ticks = time_ms // 25
    return time_ticks

def start(callback):
    """
    Starts the task manager.
    This will iterate through all added tasks every tick and check if they should be run.

    Arguments
    ---------
    onComplete: Function
        A callback function to invoke when all tasks have expired.
    """
    running = True
    while len(tasks) != 0:
        for task in tasks:
            task.__tick()
            if task.__expired:
                tasks.remove(task)
        time.sleep(tick_delay_ms / 1_000)
    running = False
    callback()