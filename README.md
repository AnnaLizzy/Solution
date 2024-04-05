# Solution
- Đây là webapp gồm api và web sắp xếp ca làm việc.
- Webapp chưa hoàn thành được, chỉ tham khảo.
##Database
WorkSchedules
  SchedulesID int primary key
  EmployeeID nvarchar(200) not null FR key Employees
  ShiftID int not null FR key WorkShifts
  LocationID int not null FR key Locations
  StartTime DateTime
  EndTime DateTime
  byweekday varchar(200)
  interval int not null
  Frequency varchar(20)
  Ví dụ
| SchedulesID | EmployeeID | ShiftID | LocationID | StartTime               | EndTime                 | byweekday              |
|-------------|------------|---------|------------|-------------------------|-------------------------|------------------------|
| 3           | 1          | 1       | QV01       | 2024-04-04 07:30:53.373 | 2024-06-04 07:30:53.373 | mo, tu, we, th, fr, sa |
###Locations
| ListID | LocationID | LocationName | Floors | X | Y | Area | Region |
|--------|------------|--------------|--------|---|---|------|--------|
| 1      |   1        |test location |   1    |235|   | Khu A|   A1   |
###WorkShifts
| ShiftID | NameShift | DescriptionShift | StartTime          | EndTime            |
|---------|-----------|------------------|---------------------|----------------------|
|    1    |   CA_HC   |  Ca hành chính  | 08:00:00.0000000 | 17:00:00.0000000 |
###Employees
| EmployeeID | EmployeeNo | Password | EmployeeName   | Gender | PhoneNumber | DateOfBirth | IsDeleted | CreateTime          | Company |
|------------|------------|----------|----------------|--------|--------------|------------|-----------|---------------------|---------|
|      1     |   V0515311 |  222222  | Nguyễn Văn An |  Nam   |  032483247   | 1997-02-25  |     0     | 2024-02-29 00:00:00 |  string |


  
