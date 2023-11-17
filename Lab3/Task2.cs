using System.Text.Json;

class Task1
{
    public enum TaskStatus
    {
        Received, // поступил
        InProgress, // готовиться
        Ready, // готов
        InWarehouse, // на складе
        OnTheRoad, // в пути
        Completed, // доставлен
        Deleted // выполнен  
    }

    public enum BakerStatus
    {
        Free, // свободен
        Busy, // занят
        Waiting // ожидает места на складе
    }

    public enum CourierStatus
    {
        Free,
        OnTheRoad,
        Return
    }

    class Pizza
    {
        public List<Baker> bakers { get; set; }
        public List<Courier> couriers { get; set; }
        public List<Task> tasks { get; set; }
        public int sizeWarehouse { get; set; }
        public int actualSizeWarehouse { get; set; }
        public int warehouseOccupancyCounter { get; set; } // счетчик заполненности склада
        public int numberOverdueOrders { get; set; } // количество просроченных заказов

        public Pizza()
        {
            bakers = ReadBakers();
            couriers = ReadCouriers();
            sizeWarehouse = 1;
            actualSizeWarehouse = 0;
            warehouseOccupancyCounter = 0;
            tasks = new List<Task>();
            numberOverdueOrders = 0;

        }
    }

    class Task
    {
        public int id { get; }
        public TaskStatus status { get; set; }
        public int time { get; private set; }
        public int maxTime { get; }
        public DeliveryTime onTheRoad { get; set; }
        public Baker baker { get; set; }
        public Courier courier { get; set; }
        public int onTheCooking { get; set; }
        public bool delayInWarehouse { get; set; }

        public Task(int _id, int _maxTime)
        {
            id = _id;
            status = TaskStatus.Received;
            time = 0;
            maxTime = _maxTime;
            baker = null;
            courier = null;
            onTheRoad = new DeliveryTime();
            onTheCooking = 0;
            delayInWarehouse = false;
        }

        public void updateStatus()
        {
            switch (status)
            {
                case TaskStatus.Received:
                    status = TaskStatus.InProgress;
                    baker.takeOrder();
                    onTheCooking = baker.time - 1; // на 1 минуту меньше, так как время уже увеличилось
                    break;
                case TaskStatus.InProgress:
                    status = TaskStatus.Ready;
                    baker.reserveSeat();
                    break;
                case TaskStatus.Ready:
                    status = TaskStatus.InWarehouse;
                    baker.updateCompletedOrders();
                    baker.free();
                    break;
                case TaskStatus.InWarehouse:
                    status = TaskStatus.OnTheRoad;
                    courier.onTheRoad();
                    onTheRoad.time++; // на 1 минуту больше, так как время уже увеличилось
                    break;
                case TaskStatus.OnTheRoad:
                    status = TaskStatus.Completed;
                    courier.returned();
                    break;
                case TaskStatus.Completed:
                    status = TaskStatus.Deleted;
                    courier.free();
                    break;
            }
        }
        public void updateTime() => time++;
        public void updateCooking() => onTheCooking--;
    }

    class Baker
    {
        public int id { get; set; }
        public BakerStatus status { get; set; }
        public int time
        {
            get { return experience == 0 ? 25 : 20 / experience + 2; } 
        }
        public int experience { get; set; }
        public int completedOrders { get; set; }

        public Baker() { }

        public Baker(int _id, int _experience)
        {
            id = _id;
            experience = _experience;
            status = BakerStatus.Free;
            completedOrders = 0;
        }

        public void free() => status = BakerStatus.Free;
        public void takeOrder() => status = BakerStatus.Busy;
        public void reserveSeat() => status = BakerStatus.Waiting;
        public void updateCompletedOrders() => completedOrders++;
    }

    class Courier
    {
        public int id { get; set; }
        public CourierStatus status { get; set; }
        public int trunkVolume { get; set; }
        public int completedOrders { get; set; } // успешно выполненные заказы
        public int overdueOrders { get; set; } // просроченные заказы

        public Courier() { }

        public Courier(int _id, int _trunkVolume)
        {
            id = _id;
            trunkVolume = _trunkVolume;
            status = CourierStatus.Free;
            completedOrders = overdueOrders = 0;

        }

        public void free() => status = CourierStatus.Free;
        public void onTheRoad() => status = CourierStatus.OnTheRoad;
        public void returned() => status = CourierStatus.Return;
        public void updateCompletedOrders() => completedOrders++;
        public void updateOverdueOrders() => overdueOrders++;

    }

    class DeliveryTime
    {
        public int EstimatedTime { get; set; } // предполагаемое время доставки заказа
        public int ActualTime { get; set; } // время, за которое курьер доставит заказ
        public int time { get; set; }

        public DeliveryTime()
        {
            Random random = new Random();
            EstimatedTime = random.Next(5, 21);
            ActualTime = EstimatedTime + random.Next(-3, 4);
        }

        public void updateTime() => time++;

        public void updateTimeReturn() => time--;


    }

    static void WriteInFile()
    {
        List<Baker> bakers = new List<Baker>
        {
            new Baker(1, 1),
            new Baker(2, 2),
            new Baker(3, 3)
        };

        List<Baker> bakers_new = new List<Baker>
        {
            new Baker(4, 5),
            new Baker(5, 6),
            new Baker(6, 2)
        };

        List<Courier> couriers = new List<Courier>
        {
            new Courier(1, 1),
            new Courier(2, 2),
            new Courier(3, 1)
        };

        List<Courier> couriers_new = new List<Courier>
        {
            new Courier(4, 1),
            new Courier(5, 3),
            new Courier(6, 2)
        };

        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\bakers.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Baker>>(fs, bakers);
            Console.WriteLine("Сохранено в файл bakers.json");
        }
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\bakers_new.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Baker>>(fs, bakers_new);
            Console.WriteLine("Сохранено в файл bakers.json");
        }
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\couriers.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Courier>>(fs, couriers);
            Console.WriteLine("Сохранено в файл couriers.json");
        }
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\couriers_new.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<List<Courier>>(fs, couriers_new);
            Console.WriteLine("Сохранено в файл couriers_new.json");
        }
    }

    static List<Baker> ReadBakers()
    {
        List<Baker> bakers;
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\bakers.json", FileMode.Open))
        {
            bakers = JsonSerializer.Deserialize<List<Baker>>(fs);
            Console.WriteLine("Загружено из файла bakers.json");
        }
        //foreach (var baker in bakers)
        //{
        //    Console.WriteLine($"Baker id: {baker.id}, experience: {baker.experience}, status: {baker.status}, time: {baker.time}");
        //}

        return bakers;
    }

    static List<Baker> ReadNewBakers()
    {
        List<Baker> bakers_new;
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\bakers_new.json", FileMode.Open))
        {
            bakers_new = JsonSerializer.Deserialize<List<Baker>>(fs);
            Console.WriteLine("Загружено из файла bakers_new.json");
        }
        //foreach (var baker in bakers_new)
        //{
        //    Console.WriteLine($"Baker id: {baker.id}, experience: {baker.experience}, status: {baker.status}, time: {baker.time}");
        //}

        return bakers_new;
    }

    static List<Courier> ReadCouriers()
    {
        List<Courier> couriers;
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\couriers.json", FileMode.Open))
        {
            couriers = JsonSerializer.Deserialize<List<Courier>>(fs);
            Console.WriteLine("Загружено из файла couriers.json");
        }
        //foreach (var courier in couriers)
        //{
        //    Console.WriteLine($"Courier id: {courier.id}, trunkVolume: {courier.trunkVolume}, status: {courier.status}," +
        //        $" CompletedOrdersToday: {courier.CompletedOrdersToday}, OverdueOrdersToday: {courier.OverdueOrdersToday}," +
        //        $" TotalCompletedOrdersToday: {courier.TotalCompletedOrdersToday}, TotalOverdueOrdersToday: {courier.TotalOverdueOrdersToday}");
        //}

        return couriers;
    }

    static List<Courier> ReadNewCouriers()
    {
        List<Courier> couriers_new;
        using (FileStream fs = new FileStream("C:\\Users\\danil\\Downloads\\couriers_new.json", FileMode.Open))
        {
            couriers_new = JsonSerializer.Deserialize<List<Courier>>(fs);
            Console.WriteLine("Загружено из файла couriers_new.json");
        }
        //foreach (var courier in couriers_new)
        //{
        //    Console.WriteLine($"Courier id: {courier.id}, trunkVolume: {courier.trunkVolume}, status: {courier.status}," +
        //        $" CompletedOrdersToday: {courier.CompletedOrdersToday}, OverdueOrdersToday: {courier.OverdueOrdersToday}," +
        //        $" TotalCompletedOrdersToday: {courier.TotalCompletedOrdersToday}, TotalOverdueOrdersToday: {courier.TotalOverdueOrdersToday}");
        //}

        return couriers_new;
    }

    static string TaskStatusPrint(TaskStatus status)
    {
        string result = status switch
        {
            TaskStatus.Received => "Поступил",
            TaskStatus.InProgress => "Готовиться",
            TaskStatus.Ready => "Готов",
            TaskStatus.InWarehouse => "На складе",
            TaskStatus.OnTheRoad => "В пути",
            TaskStatus.Completed => "Доставлен",
            TaskStatus.Deleted => "Выполнен",
            _ => "Потерялся"
        };
        return result;
    }

    static void AutomationSystem(in Pizza pizza)
    {
        var bakers_new = ReadNewBakers();
        var couriers_new = ReadNewCouriers();
        Console.WriteLine("\nРекомендации: ");
        if (pizza.warehouseOccupancyCounter > 0)
        {
            Console.WriteLine($"-Расширить склад: количество простаиваемых заказов {pizza.warehouseOccupancyCounter}");
        }

        if (pizza.numberOverdueOrders == 0)
        {
            Console.WriteLine($"-Увеличить количество заказов");
        }
        
        int countCompletedOrders = 0;
        foreach (var baker in pizza.bakers)
        {
            if (baker.completedOrders == 0)
            {
                Console.WriteLine($"-Уволить пекаря {baker.id}");
            }
            else
            {
                countCompletedOrders++;
            }
        }

        if (pizza.numberOverdueOrders > 0 && countCompletedOrders == pizza.bakers.Count && bakers_new.Count > 0)
        {
            bakers_new.Sort((baker1, baker2) => baker2.experience.CompareTo(baker1.experience));
            Console.WriteLine($"-Нанять пекаря {bakers_new[0].id}");

        }

        countCompletedOrders = 0;

        foreach (var courier in pizza.couriers)
        {
            if (courier.completedOrders - courier.overdueOrders <= 0)
            {
                Console.WriteLine($"-Уволить курьера {courier.id}");
            }
            else
            {
                countCompletedOrders++;
            }
        }

        if (pizza.numberOverdueOrders > 0 && countCompletedOrders == pizza.couriers.Count && couriers_new.Count > 0)
        {
            couriers_new.Sort((courier1, courier2) => courier2.trunkVolume.CompareTo(courier1.trunkVolume));
            Console.WriteLine($"-Нанять курьера {couriers_new[0].id}");
        }
    }

    static void Main()
    {
        //WriteInFile();
        var pizza = new Pizza();
        pizza.tasks.Add(new Task(1, 40));
        pizza.tasks.Add(new Task(2, 70));
        pizza.tasks.Add(new Task(3, 80));
        int index = 0;
        Queue<int> tasksOnWarehouse = new Queue<int>();
        while (pizza.tasks.Count > 0)
        {
            if (index == 20)
            {
                pizza.tasks.Add(new Task(20, 40));
            }

            // сортировка для приоритета заявок по времени
            //pizza.tasks.Sort((task1, task2) => task2.time.CompareTo(task1.time));
            index++;
            Console.WriteLine($"-----------------------------------------\nТакт {index}:");
            foreach (var task in pizza.tasks)
            {
                Console.WriteLine($"   Номер заказа: {task.id}. Состояние: {TaskStatusPrint(task.status)}");
                switch (task.status)
                {
                    case TaskStatus.Received:

                        foreach (var baker in pizza.bakers)
                        {
                            if (baker.status == BakerStatus.Free)
                            {
                                task.baker = baker;
                            }
                        }

                        if (task.baker is not null)
                        {
                            task.updateStatus();
                        }
                        task.updateTime();
                        break;

                    case TaskStatus.InProgress:
                        task.updateCooking();
                        task.updateTime();
                        if (task.onTheCooking <= 0)
                        {
                            task.updateStatus();
                        }
                        break;

                    case TaskStatus.Ready:
                        bool f = false;
                        if (tasksOnWarehouse.Contains(task.id) && (tasksOnWarehouse.First() == task.id))
                        {
                            f = true;
                        }

                        if ((pizza.actualSizeWarehouse < pizza.sizeWarehouse) && (tasksOnWarehouse.Count == 0 || f))
                        {
                            if (f)
                            {
                                tasksOnWarehouse.Dequeue();
                            }
                            pizza.actualSizeWarehouse++;
                            task.updateStatus();

                        }
                        else
                        {
                            if (!tasksOnWarehouse.Contains(task.id))
                            {
                                tasksOnWarehouse.Enqueue(task.id);
                            }
                            task.delayInWarehouse = true;
                            task.updateTime();
                        }
                        // если обновили статус, сразу в путь!
                        goto case TaskStatus.InWarehouse;

                    case TaskStatus.InWarehouse:
                        if (task.status != TaskStatus.Ready)
                        {
                            foreach (var courier in pizza.couriers)
                            {
                                if (courier.status == CourierStatus.Free)
                                {
                                    pizza.actualSizeWarehouse--;
                                    task.courier = courier;
                                }
                            }
                            if (task.courier is not null)
                            {
                                task.updateStatus();
                            }
                            task.updateTime();
                        }
                        break;

                    case TaskStatus.OnTheRoad:
                        task.updateTime();
                        task.onTheRoad.updateTime();
                        if (task.onTheRoad.time == task.onTheRoad.ActualTime)
                        {
                            if (task.onTheRoad.time <= task.onTheRoad.EstimatedTime)
                            {
                                task.courier.updateCompletedOrders();
                            }
                            else
                            {
                                task.courier.updateOverdueOrders();
                            }
                            task.updateStatus();
                        }
                        break;

                    case TaskStatus.Completed:
                        task.onTheRoad.updateTimeReturn();
                        if (task.onTheRoad.time == 0)
                        {
                            if (task.time > task.maxTime)
                            {
                                pizza.numberOverdueOrders++;
                                Console.WriteLine($"Время выполнения заявки {task.id} истекло. Пицца отдана бесплатно!");
                            }
                            task.updateStatus();
                            if (task.delayInWarehouse is true)
                            {
                                pizza.warehouseOccupancyCounter++;
                            }
                        }
                        break;
                }
            }
            // удаляем заявки, у которых статус Deleted
            pizza.tasks = pizza.tasks.Where(task => task.status != TaskStatus.Deleted).ToList();
        }
        Console.WriteLine("\n");
        AutomationSystem(pizza);
    }
}