package es.cifpcm.GomezRafaelMiAliSec.security;
import es.cifpcm.GomezRafaelMiAliSec.data.service.GroupService;
import es.cifpcm.GomezRafaelMiAliSec.data.service.UserService;
import es.cifpcm.GomezRafaelMiAliSec.model.Group;
import es.cifpcm.GomezRafaelMiAliSec.model.User;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.authentication.AuthenticationProvider;
import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@Configuration
@EnableWebSecurity
@EnableMethodSecurity
public class SecurityConfig {
    @Autowired
    private UserService userService;
    @Autowired
    private GroupService groupService;

    // Encriptar las contraseñas introducidas por el usuario
    protected void configure(AuthenticationManagerBuilder auth) throws Exception {
        auth.userDetailsService(userService)
                .passwordEncoder(passwordEncoder());
    }

    // Autorizacion de URLs
    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
        // URLs accesibles para todos los usuarios
        String[] roles = {
                "/",
                "/css/**",
                "/img/**",
                "/usuario/create",
                "/usuario/saveUser",
                "/error/**",
                "/producto",
                "/producto/total",
                "/producto/municipiosByProvincia",
                "/producto/productsByMunicipio",
                "/producto/details/**",
        };

        // URLs accesibles solo para clientes y administradores
        String[] roles1 = {
                "/producto/carrito",
                "/producto/addToCart",
                "/producto/deleteFromCart",
                "/producto/savePedido",
                "/producto/pedido/**",
        };

        // URLs accesibles solo para administradores
        String[] roles2 = {
                "/producto/create",
                "/producto/saveProduct",
                "/producto/update/**",
                "/producto/updateProduct",
                "/producto/delete/**",
                "/pedido/**",
                "/pedido",
                "/usuario/**",
        };

        http.authorizeHttpRequests((auth) -> auth
                .requestMatchers(roles).permitAll()
        );

        http.authorizeHttpRequests((auth) -> auth
                .requestMatchers(roles1)
                .hasAnyRole("clientes", "administradores")
        );

        http.authorizeHttpRequests((auth) -> auth
                .requestMatchers(roles2).hasAnyRole("administradores")
        );

        http.formLogin(form -> form
                .defaultSuccessUrl("/")
                .permitAll()
        );

        http.logout(form -> form
                .logoutUrl("/logout")
                .logoutSuccessUrl("/")
                .invalidateHttpSession(true)
                .deleteCookies("JSESSIONID")
        );

        return  http.build();
    }

    // Creacion de usuario al lanzar la aplicacion
    @Bean
    public boolean initializeData() {
        List<Group> groups = new ArrayList<>();

        for (int i = 1; i <= 3; i++) {
            groups.add(groupService.get(i));
        }

        userService.insertUsers(new User("admin-rafa", "123"), groups);
        return true;
    }

    // Password Encoding
    @Bean
    public PasswordEncoder passwordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Bean
    public AuthenticationProvider authenticationProvider() {
        DaoAuthenticationProvider provider = new DaoAuthenticationProvider();
        provider.setUserDetailsService(userService);
        provider.setPasswordEncoder(passwordEncoder());
        return provider;
    }
}
