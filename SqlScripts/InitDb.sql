insert into cabinetgroups (name) values ('AutoBoxes');
insert into cabinetgroups (name) values ('AC Terrein chargers');
insert into cabinetgroups (name) values ('Bus Charger');
insert into cabinetgroups (name) values ('DC Hi-Power chargers');
insert into cabinetgroups (name) values ('Simulation Labs');


insert into cabinets (name, cabinetgroup_id) values ('K0-3', 1);
insert into cabinets (name, cabinetgroup_id) values ('K0-4', 1);
insert into cabinets (name, cabinetgroup_id) values ('A0-3', 2);
insert into cabinets (name, cabinetgroup_id) values ('A0-4', 2);
insert into cabinets (name, cabinetgroup_id) values ('B0-3', 3);
insert into cabinets (name, cabinetgroup_id) values ('B0-4', 3);
insert into cabinets (name, cabinetgroup_id) values ('D0-3', 4);
insert into cabinets (name, cabinetgroup_id) values ('D0-4', 4);
insert into cabinets (name, cabinetgroup_id) values ('S0-3', 5);
insert into cabinets (name, cabinetgroup_id) values ('S0-4', 5);

insert into devicetypes (name) values ('EMax');
insert into devicetypes (name) values ('TMax');

insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.1', 'MainBreaker', 1, 1000, 1, 0);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.2', 'Sub1', 1, 1000, 1, 1);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.3', 'Sub2', 1, 1000, 1, 2);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.4', 'Sub3', 1, 1000, 1, 3);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.5', 'Sub4', 1, 1000, 1, 4);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.6', 'Sub5', 1, 1000, 1, 5);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.3.7', 'Sub6', 1, 1000, 1, 6);

insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.1', 'MainBreaker', 2, 1000, 2, 0);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.2', 'Sub1', 2, 1000, 2, 1);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.3', 'Sub2', 2, 1000, 2, 2);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.4', 'Sub3', 2, 1000, 2, 3);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.5', 'Sub4', 2, 1000, 2, 4);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.6', 'Sub5', 2, 1000, 2, 5);
insert into devices (plc_device_id, name, devicetype_id, max_value, cabinet_id, cabinet_position)
values('0.4.7', 'Sub6', 2, 1000, 2, 6);