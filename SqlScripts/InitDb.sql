insert into devicetypes (name) values ('Emax');
insert into devicetypes (name) values ('Tmax');

insert into cabinets (name) values ('cabinet1');

insert into cabinetgroups (name) values ('cabinetgroup1');

insert into devices (device_id, devicetype_id, max_value, cabinetgroup_id, cabinet_id, cabinet_position)
values('0.3.1', 1, 1000, 1, 1, 0);
insert into devices (device_id, devicetype_id, max_value, cabinetgroup_id, cabinet_id, cabinet_position)
values('0.3.2', 1, 800, 1, 1, 1);
insert into devices (device_id, devicetype_id, max_value, cabinetgroup_id, cabinet_id, cabinet_position)
values('0.4.1', 2, 900, 1, 1, 0);