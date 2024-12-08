# Lançamento Oblíquo - Jogo em Unity

## Descrição

Este é um jogo desenvolvido na Unity que simula o lançamento oblíquo de projéteis, permitindo que o jogador ajuste parâmetros físicos como a massa do projétil, a velocidade de lançamento para alcançar um alvo. Cada fase apresenta desafios únicos, como diferentes ambientes (ar ou água) e propriedades físicas variadas, oferecendo um cenário dinâmico e envolvente para os jogadores.

[Link para jogar :)](https://pedr-lunkes.itch.io/as-aventuras-fisicas-de-magomerindo)
---
## Mecânicas de Jogabilidade

### **Parâmetros Ajustáveis**

1. **Velocidade Inicial ($v_0$)**: Define a força aplicada ao projétil. Jogadores podem aumentar ou diminuir a velocidade inicial para ajustar a distância que o projétil percorre.
   
2. **Ângulo de Lançamento ($\theta$)**: Afeta diretamente a trajetória parabólica. Jogadores precisam encontrar o ângulo ideal para atingir o alvo com precisão.

3. **Massa do Projétil ($m$)**: Jogadores podem experimentar com projéteis leves e pesados, ajustando sua estratégia conforme a inércia e a gravidade afetam a jogabilidade.

4. **Ambiente (Ar ou Água)**: Em fases subaquáticas, o coeficiente de arrasto simula a resistência do meio. O projétil desacelera mais rapidamente, exigindo maior precisão nos ajustes iniciais.

---

## Física Aplicada ao Jogo

O jogo implementa a simulação física do **lançamento oblíquo**, baseada nas leis clássicas da mecânica de Newton.

![Movimento parabólico de um projétil em um lançamento oblíquo](img/lançamento.png)

No lançamento oblíquo, consideramos um projétil de massa $$( m \)$$, lançado com uma velocidade inicial $$\vec{v_0}$$, fazendo um ângulo $$( \theta \)$$ com o solo (eixo $$( Y \)$$). A trajetória descrita pelo projétil é parabólica devido à influência da gravidade $$( \vec{F}_g \)$$, cuja força é vertical e dirigida para baixo.

### Sistema de Coordenadas

Para simplificar os cálculos, colocamos o lançamento no plano $$( YZ \)$$, onde:
- O eixo $$( Y \)$$ é perpendicular ao solo e representa o movimento vertical.
- O eixo $$( X \)$$ está sobre o solo e representa o movimento horizontal.

A origem $$\vec{r_t}$$ é definida como o ponto inicial do lançamento, com $$( t_i = 0 \)$$.

---

### Vetores em Coordenadas

Neste projeto, trabalhamos com o sistema $$( XY \)$$, por se tratar de um jogo em 2D. descrevemos os vetores posição, velocidade e aceleração do projétil da seguinte forma:

1. **Gravidade**:

$$
\vec{F}_g = -mg\hat{k}, \text{m/s}^2
$$

Sendo $${g = 9,8}$$ para as fases na Terra, aproximadamente $${g = 1,6}$$ para a fase na Lua, $${g = 0,1}$$ para o planeta criado para a fase 5 e $${g = 25,6}$$ para o planeta criado para a fase 6.

2. **Posição**:

$$
\vec{r}(t) = x(t)\hat{i} + y(t)\hat{j}
$$

3. **Velocidade**:

$$
\vec{v}(t) = \dot{x}(t)\hat{i} + \dot{y}(t)\hat{j}
$$

4. **Aceleração**:

$$
\vec{a}(t) = \ddot{x}(t)\hat{i} + \ddot{y}(t)\hat{j}
$$

5. **Força Viscosa**:

Para cálculo da força viscosa, tomamos de base a Lei de Stokes:

$$
\vec{F}_v = 6 \pi \eta \vec{v} r, \text{m/s}^2
$$

Com $$\eta$$ sendo o coeficiente de viscosidade dinâmica do meio, $$v$$ sendo a velocidade do objeto e $$r$$ o raio do objeto esférico (usado como base para o nosso projétil). Para efeito de simplificação de cálculo, consideramos o nosso $$r = 1 / (6 \pi)$$. Dessa forma, o cálculo da força viscosa se dá como:

$$
\vec{F}_v = \eta \vec{v} , \text{m/s}^2
$$

Assumimos os valores de $${\eta = 10^{-3}}$$ para a fase da água, $${\eta = 1,8^{-5}}$$ para a do ar, $${\eta = 1,975}$$ para a do mel, $${\eta = 0}$$ para a do espaço pela falta de atmosfera e foi pensado um valor de $${\eta = 6,34}$$ para o planeta criado para a fase 5 e $${\eta = 12,69}$$ para a fase 6.

---

## Movimento de Lançamento Oblíquo com Força Viscosa

Este documento descreve o passo a passo para resolver as equações de movimento de um objeto em lançamento oblíquo, levando em consideração a força viscosa, proporcional à $${ \eta v }$$.

### 1. Descrição do Sistema

Considere um objeto sendo lançado com uma velocidade inicial $${ v_0 }$$ e um ângulo de lançamento $${ \theta_0 }$$ em um fluido viscoso. As forças que atuam sobre o objeto são:

- **Força de gravidade** $${ F_g = mg }$$ (para baixo, na direção $${ y }$$).
- **Força viscosa** $${ F_{v} = \eta v }$$, onde $${ v }$$ é a velocidade do objeto, e $${ \eta }$$ é a viscosidade do fluido.

#### 1.1. Equações de Movimento

As equações de movimento nas direções $${ x }$$ (horizontal) e $${ y }$$ (vertical) são:

- **Direção $${ x }$$ (horizontal)**:

$$
m \frac{d^2 x}{dt^2} = -\eta \frac{dx}{dt}
$$

  Onde $${ \frac{dx}{dt} = v_x }$$ é a velocidade na direção $${ x }$$.

- **Direção $${ y }$$ (vertical)**:

$$
m \frac{d^2 y}{dt^2} = -mg - \eta \frac{dy}{dt}
$$

  Onde $${ \frac{dy}{dt} = v_y }$$ é a velocidade na direção $${ y }$$, e $${ -mg }$$ representa a força de gravidade.

### 2. Soluções para a Velocidade

As equações de movimento podem ser resolvidas para as velocidades $${ v_x(t) }$$ e $${ v_y(t) }$$, integrando as equações diferenciais.

#### 2.1. Solução para $${ v_x(t) }$$

A equação para a velocidade $${ v_x }$$ é dada por:

$$
m \frac{d v_x}{dt} = -\eta v_x
$$

Ou seja, a aceleração na direção $${ x }$$ é proporcional à velocidade $${ v_x }$$.

A solução para $${ v_x(t) }$$ é:

$$
v_x(t) = v_{x0} \exp\left(-\frac{\eta}{m} t\right)
$$

Onde $${ v_{x0} = v_0 \cos(\theta_0) }$$ é a velocidade inicial na direção $${ x }$$.

#### 2.2. Solução para $${ v_y(t) }$$

A equação para a velocidade $${ v_y }$$ é dada por:

$$
m \frac{d v_y}{dt} = -mg - \eta v_y
$$

A solução para $${ v_y(t) }$$ pode ser obtida considerando a solução homogênea (decadência exponencial) e uma solução particular para o termo constante $${ -mg }$$. A solução geral para $${ v_y(t) }$$ é:

$$
v_y(t) = \left( v_{0y} + \frac{mg}{\eta} \right) e^{-\frac{\eta}{m}t} - \frac{mg}{\eta}
$$

Onde $${ v_{y0} = v_0 \sin(\theta_0) }$$ é a velocidade inicial na direção $${ y }$$.

### 3. Soluções para a Posição

Agora, para encontrar a posição $${ x(t) }$$ e $${ y(t) }$$, integramos as soluções para $${ v_x(t) }$$ e $${ v_y(t) }$$.

#### 3.1. Posição na direção $${ x }$$

A posição $${ x(t) }$$ é dada pela integral de $${ v_x(t) }$$:

$$
x(t) = \int v_x(t) dt = \int v_{x0} \exp\left(-\frac{\eta}{m} t\right) dt
$$

A solução para $${ x(t) }$$ é:

$$
x(t) = \frac{m}{\eta} v_{x0} \left( 1 - \exp\left(-\frac{\eta}{m} t\right) \right)
$$

#### 3.2. Posição na direção $${ y }$$

A posição $${ y(t) }$$ é dada pela integral de $${ v_y(t) }$$:

$$
y(t) = \int_0^t v_y(t) \, dt
$$

Substituindo $${ v_y(t) }$$ pela expressão encontrada anteriormente:

$$
y(t) = \left( v_{0y} + \frac{mg}{\eta} \right) \frac{m}{\eta} \left( 1 - e^{-\frac{\eta}{m}t} \right) - \frac{mg}{\eta} \left( t - \frac{m}{\eta} \left( 1 - e^{-\frac{\eta}{m}t} \right) \right)
$$

### 4. Condições Iniciais

As condições iniciais são definidas no momento $${ t = 0 }$$:

- Posição inicial: $${ x(0) = 0 }$$ e $${ y(0) = 0 }$$
- Velocidade inicial: $${ v_x(0) = v_0 \cos(\theta_0) }$$ e $${ v_y(0) = v_0 \sin(\theta_0) }$$

Estas condições determinam as constantes $${ v_{x0} = v_0 \cos(\theta_0) }$$ e $${ v_{y0} = v_0 \sin(\theta_0) }$$, usadas nas soluções das equações de movimento.

### 5. Resultados Finais

As soluções para as velocidades e posições nas direções $${ x }$$ e $${ y }$$ são:

- **Velocidade na direção $${ x }$$**:

$$
v_x(t) = v_0 \cos(\theta_0) \exp\left(-\frac{\eta}{m} t\right)
$$

- **Posição na direção $${ x }$$**:

$$
x(t) = \frac{m}{\eta} v_0 \cos(\theta_0) \left( 1 - \exp\left(-\frac{\eta}{m} t\right) \right)
$$

- **Velocidade na direção $${ y }$$**:

$$
v_y(t) = v_0 \sin(\theta_0) \exp\left(-\frac{\eta}{m} t\right) - \frac{mg}{\eta}
$$

- **Posição na direção $${ y }$$**:

$$
y(t) = \frac{m}{\eta} v_0 \sin(\theta_0) \left( 1 - \exp\left(-\frac{\eta}{m} t\right) \right) - \frac{mg}{\eta} t
$$

---

## Estratégias Baseadas na Física

Para dominar o jogo, os jogadores devem aplicar conceitos de física ao ajustar os parâmetros:

1. **Máximo Alcance Horizontal**: Para alcançar o maior alcance possível, o ângulo de lançamento deve ser próximo de $45^\circ$, em ambientes sem arrasto.

2. **Trajetória Precisa em Ambientes Resistivos**: Fases que incluem resistência do ar ou água exigem um lançamento mais direto, com ângulos menores ($<45^\circ$) para compensar a desaceleração.

3. **Controle da Massa**: Em fases com obstáculos, usar projéteis mais pesados pode ajudar a manter uma trajetória mais estável, enquanto projéteis leves são ideais para atingir alvos em áreas de difícil acesso.

---
## Movimento no Campo Gravitacional

O movimento do projétil é regido pela gravidade e segue uma trajetória parabólica quando a força viscosa é desprezada. As equações clássicas são implementadas para calcular a posição e a velocidade do projétil em tempo real:

#### **Movimento Horizontal**
A posição horizontal é descrita por:

$$
z(t) = v_0 \cdot \cos(\theta) \cdot t
$$

- $v_0$: velocidade inicial.
- $\theta$: ângulo de lançamento.
- $t$: tempo.

#### **Movimento Vertical**
A posição vertical, que inclui o efeito da gravidade, é dada por:

$$
z(t) = v_0 \cdot \sin(\theta) \cdot t - \frac{1}{2} g t^2
$$

- $g$: aceleração gravitacional ($9,81 \, m/s^2$ na Terra).

A velocidade vertical muda com o tempo devido à gravidade:

$$
v_z(t) = v_0 \cdot \sin(\theta) - g \cdot t
$$
## Alcance Máximo e Trajetória

1. O alcance máximo ocorre para $$( \theta = \frac{\pi}{4} \)$$ (ou $${ 45^\circ })$$, onde a derivada do alcance em função de $${ \theta }$$ é zero.

2. A trajetória é uma parábola no plano $$\( XY \)$$, conforme descrito pelas equações acima.

---

Essas deduções podem ser aplicadas diretamente ao jogo, validando os cálculos de trajetória e comportamento físico do projétil para diferentes condições ajustadas pelo jogador.
## Massa do Projétil

No jogo, o jogador pode ajustar a massa do projétil, que afeta sua aceleração conforme a segunda lei de Newton:

$$
F = m \cdot a
$$

Isso significa que projéteis mais leves podem ser lançados mais facilmente, mas são mais suscetíveis a forças externas (como a força de viscosidade), enquanto projéteis mais pesados mantêm sua inércia, mas têm trajetórias mais curtas devido à gravidade.

---

## Cálculo da Velocidade no Instante \( t \)

Para calcular a velocidade do objeto no instante \( t \), utilizamos o **método de Euler**, uma técnica numérica para aproximar soluções de equações diferenciais ordinárias (EDOs). A equação diferencial que rege o movimento é:

$$
\vec{a}(t) = \frac{d\vec{v}(t)}{dt},
$$

onde $$\vec{a                                                                                                                                                                                                                                                                                           }$$ é a aceleração no instante \( t \) e $$\vec{v}$$ é a velocidade.

Aplicando o método de Euler, a velocidade no instante \( t + $$\Delta$$ t \) é calculada como:

$$
\vec{v}(t + \Delta t) = \vec{v}(t) + \vec{a}(t) \cdot \Delta t,
$$

onde:
- $$\Delta$$ t é o intervalo de tempo entre as iterações (DeltaTime no Unity, que mede o tempo entre os frames renderizados),
- $$\vec{v}$$ é a velocidade conhecida no instante atual,
- $$\vec{a}$$ é calculada com base nas forças atuantes no objeto.
Essa abordagem permite uma atualização iterativa da velocidade em cada passo de tempo, sendo eficiente e suficientemente precisa para os objetivos do jogo.




## Tecnologias Utilizadas

- **Engine**: Unity 2023.x.
- **Linguagem**: C#.
- **Movimento de Projetéis**: Física 2D
## Referências

1. **Notas de Aula** - dinamica-v4.pdf
2. **Método de Euler** - Wikipedia
3. [**Viscosidade**](https://edisciplinas.usp.br/pluginfile.php/8310622/mod_resource/content/1/Apostila%202_Viscosidade_2024.pdf#:~:text=Tipicamente%2C%20a%20%C3%A1gua%2C%20a%20temperatura,redor%20de%2030%20%C2%B0C.)
4. [**Coeficientes de Viscosidade**](http://www.escoladavida.eng.br/mecfluquimica/planejamento_12009/mecflu1.pdf)
5. [**Unity Documentation**](https://www.google.com/url?sa=t&source=web&rct=j&opi=89978449&url=https://docs.unity.com/&ved=2ahUKEwjP8-a914uKAxUeqZUCHS1oBuwQFnoECA0QAQ&usg=AOvVaw1tl3GibVO-rZ_iA7vfnovN)


## Autores

| Nome                                |
|:-----------------------------------:|
| Dante Brito Lourenço                |
| Frederico Scheffel Oliveira         |
| João Gabriel Pieroli da Silva       |
| Laura Fernandes Camargos            |
| Leonardo Massuhiro Sato             |
| Nicolas Amaral dos Santos           |
| Pedro Henrique de Sousa Prestes     |
| Pedro Henrique Perez Dias           |
| Pedro Lunkes Villela                |
