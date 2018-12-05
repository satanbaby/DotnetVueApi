<template>
  <div>
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
          <div class="sidebar-sticky">
            <ul class="nav flex-column">
              <li class="nav-item">
                <router-link :to='{name:"Product"}'>產品列表</router-link>
              </li>
              <li class="nav-item">
                <router-link :to='{name:"PrdMan"}'>產品管理</router-link>
              </li>
              <li class="nav-item">
                <router-link :to='{name:"Order"}'>購物車</router-link>
              </li>
              <li class="nav-item">
                <router-link :to='{name:"Registered"}'>註冊</router-link>
              </li>
              <li class="nav-item">
                <router-link :to='{name:"Member"}'>會員管理</router-link>
              </li>
            </ul>
          </div>
        </nav>
  </div>
</template>
