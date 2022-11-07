const Home = () => {
    return (
        <main>
            <h1>Welcome to Invoice Browser</h1>
            <section>
                It was built with Asp.Net Core Web API, Entity Framework, Fluent Validation and AutoMapper.
            </section>
            <section>
                Client app was built with React, Redux (@ReduxToolkit) and Material UI.
            </section>
            <h5>API documentation on Swagger: {`https://<backend-address>/swagger/index.html}`}</h5>
            <h6><a href="https://localhost:7253/swagger/index.html">https://localhost:7253/swagger/index.html</a></h6>
        </main>
        
    )
}

export default Home;