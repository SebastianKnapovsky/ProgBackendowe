package com.example.demo;

import java.util.ArrayList;

public class UserController {

    @RequestMapping("/users")
    @ResponseBody
    public Object getUsers(
            @ResponseParam Intiger pageNumber,
            @ResponsParam Intiger pageSize

    ){
       List<UserEntity> users = new ArrayList<>();

       users.add(new UserEntity(id: 1L, name: "John"));
       users.add(new UserEntity(id: 2L, name: "Matt"));

       return users;
    }
    @RequestMapping("/users/{id}")
    @ResponseBody
    public Object getUsers(
            @PathVariable Long id
    ){
        return new UserEntity(id, name: "John" + id);
    }
}
